using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        public IEnumerable<GetCustomerResponse> MapEntitiesToResponseModels(IEnumerable<CustomerEntity> customers)
        {
            List<GetCustomerResponse> responses = new List<GetCustomerResponse>();

            foreach (var customer in customers)
            {
                responses.Add(MapEntityToResponseModel(customer));
            }

            return responses;
        }

        public GetCustomerResponse MapEntityToResponseModel(CustomerEntity customer)
        {
            return new GetCustomerResponse
            {
                Id = customer.Id,
                CreatedDate = customer.CreatedDate,
                CustomerName = customer.CustomerName,
                Contacts = customer.Contacts?.Select(c => new GetCustomerContactResponse
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ContactNumber = c.ContactNumber,
                    Address = c.Address,
                    CreatedDate = c.CreatedDate,
                }).ToList()
            };
        }

        public CustomerEntity MapRequestModelToEntity(CreateCustomerRequest request)
        {
            return new CustomerEntity
            {
                CreatedDate = DateTime.Now,
                CustomerName = request.CustomerName,
                Contacts = request.Contacts?.Select(c => new CustomerContactEntity
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ContactNumber = c.ContactNumber,
                    Address = c.Address,
                    CreatedDate = DateTime.Now,
                }).ToList()
            };
        }

        public CustomerEntity MapRequestModelToEntity(UpdateCustomerRequest request)
        {
            return new CustomerEntity
            {
                CreatedDate = DateTime.Now,
                CustomerName = request.CustomerName,
                Contacts = request.Contacts?.Select(c => new CustomerContactEntity
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ContactNumber = c.ContactNumber,
                    Address = c.Address,
                    CreatedDate = DateTime.Now,
                }).ToList()
            };
        }
    }
}
