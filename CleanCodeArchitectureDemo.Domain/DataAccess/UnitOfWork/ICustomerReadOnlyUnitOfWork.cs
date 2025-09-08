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
        Task<IEnumerable<GetCustomerResponse>> GetAllCustomerAsync();
        Task<GetCustomerResponse> GetCustomerAsync(int id);
        Task<IEnumerable<GetCustomerContactResponse>> GetCustomerContactsByCustomerId(int customerId);
        Task<GetCustomerContactResponse> GetCustomerContactById(int Id);
    }
}