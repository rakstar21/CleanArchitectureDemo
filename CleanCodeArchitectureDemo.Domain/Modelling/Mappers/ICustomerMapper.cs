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
        IEnumerable<GetCustomerResponse> MapEntitiesToResponseModels(IEnumerable<CustomerEntity> customers);
        GetCustomerResponse MapEntityToResponseModel(CustomerEntity customer);
        CustomerEntity MapRequestModelToEntity(CreateCustomerRequest request);
        CustomerEntity MapRequestModelToEntity(UpdateCustomerRequest request);
    }
}
