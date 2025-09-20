using MediatR;
using SM.Application.CQRS.Query;
using SM.Application.DTOs;
using SM.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Hanlders
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentQuery, List<StudentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStudentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.Students.ListAsync();
            if(students == null || !students.Any()) return new List<StudentDto>();
            return students.Select(student => new StudentDto(student.Id, student.FullName, student.Email, student.DateOfBirth)).ToList();
        }
    }
}
