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
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDto?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetStudentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentDto?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(request.Id);
            if (student == null) return null;
            return new StudentDto(student.Id, student.FullName, student.Email, student.DateOfBirth);
        }
    }
}
