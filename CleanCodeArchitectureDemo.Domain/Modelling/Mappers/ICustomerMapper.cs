using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Mappers
{
    public interface ICustomerMapper
    {
        GetCustomerContactResponse MapEntitiesToResponseModel(CustomerEntity customer, IEnumerable<CustomerContactEntity> contacts);
        CustomerEntity MapRequestModelToEntity(CreateCustomerRequest request);
        CustomerEntity MapRequestModelToEntity(UpdateCustomerRequest request);
    }
}
