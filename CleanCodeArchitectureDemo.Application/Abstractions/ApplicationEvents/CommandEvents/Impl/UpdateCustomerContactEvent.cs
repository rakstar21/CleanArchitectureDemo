using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents.Impl
{
    public class UpdateCustomerContactEvent : IUpdateCustomerContactEvent
    {
        public UpdateCustomerContactEvent(UpdateCustomerContactRequest request)
        {
            Request = request;
        }

        public UpdateCustomerContactRequest Request { get; }
    }
}
