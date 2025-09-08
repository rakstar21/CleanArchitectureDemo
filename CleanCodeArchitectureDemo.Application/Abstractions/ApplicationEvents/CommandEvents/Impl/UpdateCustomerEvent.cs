using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents.Impl
{
    public class UpdateCustomerEvent : IUpdateCustomerEvent
    {
        public UpdateCustomerEvent(UpdateCustomerRequest request)
        {
            Request = request;
        }

        public UpdateCustomerRequest Request { get; }
    }
}
