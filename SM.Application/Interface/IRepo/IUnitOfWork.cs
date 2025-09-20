using SM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Interface.IRepo
{
    public interface IUnitOfWork
    {
        IGenericRepo<Student> Students { get; }
        IGenericRepo<Course> Courses { get; }
        Task<int> CompleteAsync(); // commit
    }
}
