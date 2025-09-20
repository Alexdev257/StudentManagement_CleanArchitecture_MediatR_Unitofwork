using MediatR;
using SM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Query
{
    public record GetStudentByIdQuery(Guid Id) : IRequest<StudentDto?>;
}
