using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.Domain.Entities;
using SM.Application.CQRS.Command;
using SM.Application.DTOs;
using SM.Application.Interface;

namespace SM.Application.CQRS.Hanlders
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FullName = request.FullName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth
            };
            _unitOfWork.Students.Add(student);
            await _unitOfWork.CompleteAsync();
            //return new StudentDto(student.Id, student.FullName, student.Email, student.DateOfBirth);
            return Unit.Value;
        }
    }
}
