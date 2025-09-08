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
        Task<int> CreateCustomerAsync(CreateCustomerRequest request);
        Task UpdateCustomerAsync(UpdateCustomerRequest request);
        Task DeleteCustomerAsync(int customerId);

        Task<int> CreateCustomerContactAsync(CreateCustomerContactRequest request);
        Task CreateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request);
        Task UpdateCustomerContactAsync(UpdateCustomerContactRequest request);
        Task UpdateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request);
        Task DeleteCustomerContactAsync(int customerId);
    }
}
