using MediatR;
using SM.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.CQRS.Query
{
    public record GetAllStudentQuery() : IRequest<List<StudentDto>>;
}
