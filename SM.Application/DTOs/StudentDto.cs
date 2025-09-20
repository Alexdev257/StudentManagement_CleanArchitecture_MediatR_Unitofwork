using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.DTOs
{
    public record StudentDto(Guid Id, string FullName, string Email, DateTime DateOfBirth);
}
