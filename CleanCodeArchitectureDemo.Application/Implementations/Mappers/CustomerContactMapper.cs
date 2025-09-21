using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.Mappers
{
    public class CustomerContactMapper : ICustomerContactMapper
    {
        public IEnumerable<GetCustomerContactResponse> MapEntitiesToResponseModels(IEnumerable<CustomerContactEntity> customers)
        {
            List<GetCustomerContactResponse> responses = new List<GetCustomerContactResponse>();

            foreach (var customer in customers)
            {
                responses.Add(MapEntityToResponseModel(customer));
            }

            return responses;
        }

        public GetCustomerContactResponse MapEntityToResponseModel(CustomerContactEntity customer)
        {
            return new GetCustomerContactResponse
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                ContactNumber = customer.ContactNumber,
                Address = customer.Address,
                CreatedDate = customer.CreatedDate,
            };
        }

        public IEnumerable<CustomerContactEntity> MapRequestModelsToEntities(IEnumerable<CreateCustomerContactRequest> request)
        {
            List<CustomerContactEntity> entities = new List<CustomerContactEntity>();
            foreach (var model in request) 
            {
                entities.Add(MapRequestModelToEntity(model));
            }
            return entities;
        }

        public IEnumerable<CustomerContactEntity> MapRequestModelsToEntities(IEnumerable<UpdateCustomerContactRequest> request)
        {
            List<CustomerContactEntity> entities = new List<CustomerContactEntity>();
            foreach (var model in request)
            {
                entities.Add(MapRequestModelToEntity(model));
            }
            return entities;
        }

        public CustomerContactEntity MapRequestModelToEntity(CreateCustomerContactRequest request)
        {
            return new CustomerContactEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                Address = request.Address,
                CreatedDate = DateTime.Now,
                CustomerId = request.CustomerId,
            };
        }

        public CustomerContactEntity MapRequestModelToEntity(UpdateCustomerContactRequest request)
        {
            return new CustomerContactEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                Address = request.Address,
                CreatedDate = DateTime.Now,
                CustomerId = request.CustomerId,
            };
        }
    }
}
