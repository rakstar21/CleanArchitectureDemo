using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Mappers
{
    public interface ICustomerContactMapper
    {
        IEnumerable<GetCustomerContactResponse> MapEntitiesToResponseModels(IEnumerable<CustomerContactEntity> customers);
        GetCustomerContactResponse MapEntityToResponseModel(CustomerContactEntity customer);
        CustomerContactEntity MapRequestModelToEntity(CreateCustomerContactRequest request);
        IEnumerable<CustomerContactEntity> MapRequestModelsToEntities(IEnumerable<CreateCustomerContactRequest> request);
        CustomerContactEntity MapRequestModelToEntity(UpdateCustomerContactRequest request);
        IEnumerable<CustomerContactEntity> MapRequestModelsToEntities(IEnumerable<UpdateCustomerContactRequest> request);
    }
}
