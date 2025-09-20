using MediatR;
using SM.Application.DTOs;
using SM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Query
{
    public class GetStudentByIdQueryNoRecord : IRequest<StudentRes>
    {
        public Guid Id { get; set; }
    }
}
