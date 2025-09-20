using MediatR;
using SM.Application.CQRS.Command;
using SM.Application.DTOs;
using SM.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Hanlders
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _unitOfWork.Students.GetByIdAsync(request.Id);
            if (student == null) throw new Exception("Student not found");
            student.Result.FullName = request.FullName;
            student.Result.Email = request.Email;
            student.Result.DateOfBirth = request.DateOfBirth;
            _unitOfWork.Students.Update(student.Result);
            _unitOfWork.CompleteAsync();
            return Task.FromResult(new StudentDto(student.Result.Id, student.Result.FullName, student.Result.Email, student.Result.DateOfBirth));
        }
    }
}
