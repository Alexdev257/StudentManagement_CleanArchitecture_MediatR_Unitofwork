using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Application.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
