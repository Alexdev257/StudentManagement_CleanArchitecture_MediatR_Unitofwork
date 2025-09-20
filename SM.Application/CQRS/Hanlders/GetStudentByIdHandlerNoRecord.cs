using MediatR;
using SM.Application.CQRS.Query;
using SM.Application.DTOs;
using SM.Application.Interface;
using SM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Hanlders
{
    public class GetStudentByIdHandlerNoRecord : IRequestHandler<GetStudentByIdQueryNoRecord, StudentRes>
    {
        private IUnitOfWork _unitOfWork;
        public GetStudentByIdHandlerNoRecord(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentRes> Handle(GetStudentByIdQueryNoRecord request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(request.Id);
            var student2 = await _unitOfWork.Students.GetByIdAsync(request.Id);
            var stDto = new StudentDto(student2.Id, student2.FullName, student2.Email, student2.DateOfBirth);
            if (student == null) throw new Exception("Student not found");
            var rs = new StudentRes
            {
                FullName = student.FullName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Student2 = stDto,
            };
            //return student;
            return rs;

        }
    }
}
