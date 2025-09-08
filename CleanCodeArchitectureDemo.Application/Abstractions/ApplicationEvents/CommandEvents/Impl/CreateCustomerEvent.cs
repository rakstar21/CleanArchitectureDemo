using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents.Impl
{
    public class CreateCustomerEvent : ICreateCustomerEvent
    {
        public CreateCustomerEvent(CreateCustomerRequest request, bool includeDependencies = false)
        {
            Request = request;
            IncludeDependencies = includeDependencies;
        }

        public CreateCustomerRequest Request { get; }
        public bool IncludeDependencies { get; }
    }
}