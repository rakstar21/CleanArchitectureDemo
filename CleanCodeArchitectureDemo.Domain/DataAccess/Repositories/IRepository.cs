using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
