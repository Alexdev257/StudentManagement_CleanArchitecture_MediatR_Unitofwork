using MediatR;
using Microsoft.AspNetCore.Mvc;
using SM.Application.CQRS.Command;
using SM.Application.CQRS.Query;

namespace SM.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-Student")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var studentDto = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetById), new { id = studentDto.Id }, studentDto);
            return Created("abcxyz", new { message = "Created Successfully" });
        }

        [HttpGet("get-student{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _mediator.Send(new GetStudentByIdQuery(id));
            return res == null ? NotFound() : Ok(res);
        }

        [HttpGet("get-all-students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _mediator.Send(new GetAllStudentQuery());
            return Ok(students);
        }

        [HttpPut("update-student{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentCommand command)
        {
            var updatedStudent = await _mediator.Send(command);
            return Ok(updatedStudent);
        }

        [HttpGet("test-no-record")]
        public async Task<IActionResult> TestNoRecord(Guid Id)
        {
            var student = await _mediator.Send(new GetStudentByIdQueryNoRecord() { Id = Id});
            return student == null ? NotFound() : Ok(student);
        }
    }
}
