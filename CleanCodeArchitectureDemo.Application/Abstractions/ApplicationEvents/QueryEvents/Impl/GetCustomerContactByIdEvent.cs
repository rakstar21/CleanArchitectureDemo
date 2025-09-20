using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents.Impl
{
    public class GetCustomerContactByIdEvent : IGetCustomerContactByIdEvent
    {
        public int CustomerId { get; set; }
    }
}
