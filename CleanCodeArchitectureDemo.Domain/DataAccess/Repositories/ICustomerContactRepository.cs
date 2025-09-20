using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.Repositories
{
    public interface ICustomerContactRepository: IRepository<CustomerContactEntity>
    {
        Task<IEnumerable<CustomerContactEntity>> GetContactsByCustomerId(int customerId, CancellationToken cancellationToken = default);
        Task DeleteContactsByCustomerId(int customerId, CancellationToken cancellationToken = default);
        Task UpdateCustomerContactsAsync(IEnumerable<CustomerContactEntity> request, CancellationToken cancellationToken = default);
    }
}
