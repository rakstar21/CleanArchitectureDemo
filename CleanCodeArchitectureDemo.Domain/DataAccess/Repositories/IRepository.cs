using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> GetById(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
    }
}
