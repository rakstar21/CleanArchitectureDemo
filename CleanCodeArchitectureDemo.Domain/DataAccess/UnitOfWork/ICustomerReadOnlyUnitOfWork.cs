using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork
{
    public interface ICustomerReadOnlyUnitOfWork: IReadOnlyUnitOfWork
    {
        Task<IEnumerable<GetCustomerResponse>> GetAllCustomerAsync(CancellationToken cancellationToken = default);
        Task<GetCustomerResponse> GetCustomerAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<GetCustomerContactResponse>> GetCustomerContactsByCustomerId(int customerId, CancellationToken cancellationToken = default);
        Task<GetCustomerContactResponse> GetCustomerContactById(int Id, CancellationToken cancellationToken = default);
    }
}