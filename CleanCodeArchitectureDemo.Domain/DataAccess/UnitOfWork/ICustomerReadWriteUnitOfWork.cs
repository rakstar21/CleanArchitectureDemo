using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork
{
    public interface ICustomerReadWriteUnitOfWork: IReadWriteUnitOfWork
    {
        Task CreateCustomerAsync(CreateCustomerRequest request);
        Task UpdateCustomerAsync(UpdateCustomerRequest request);
        Task DeleteCustomerAsync(int customerId);
    }
}
