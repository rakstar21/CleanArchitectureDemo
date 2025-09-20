using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork
{
    public interface ICustomerReadWriteUnitOfWork: ICustomerReadOnlyUnitOfWork, IReadWriteUnitOfWork
    {
        Task<int> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default);
        Task UpdateCustomerAsync(UpdateCustomerRequest request, CancellationToken cancellationToken = default);
        Task DeleteCustomerAsync(int customerId, CancellationToken cancellationToken = default);

        Task<int> CreateCustomerContactAsync(CreateCustomerContactRequest request, CancellationToken cancellationToken = default);
        Task CreateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request, CancellationToken cancellationToken = default);
        Task UpdateCustomerContactAsync(UpdateCustomerContactRequest request, CancellationToken cancellationToken = default);
        Task UpdateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request, CancellationToken cancellationToken = default);
        Task DeleteCustomerContactAsync(int customerId, CancellationToken cancellationToken = default);
    }
}
