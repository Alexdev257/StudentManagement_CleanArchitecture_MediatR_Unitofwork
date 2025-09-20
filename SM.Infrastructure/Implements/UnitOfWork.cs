using SM.Application.Interface;
using SM.Domain.Entities;
using SM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Students = new GRepo<Student>(_context);
            Courses = new GRepo<Course>(_context);
        }

        public IGenericRepo<Student> Students { get; }
        public IGenericRepo<Course> Courses { get; }
        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
