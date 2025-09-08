using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents.Impl
{
    public class CreateCustomerContactEvent : ICreateCustomerContactEvent
    {
        public CreateCustomerContactEvent(CreateCustomerContactRequest request)
        {
            Request = request;
        }

        public CreateCustomerContactRequest Request { get; }
    }
}
