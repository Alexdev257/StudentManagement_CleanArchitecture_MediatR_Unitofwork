using Microsoft.EntityFrameworkCore;
using SM.Application.Interface;
using SM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infrastructure.Implements
{
    public class GRepo<T> : IGenericRepo<T> where T : class
    {

        protected readonly ApplicationDbContext _context;

        public GRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            //_dbSet.Add(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
