using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents.Impl
{
    public class GetCustomerById : IGetCustomerById
    {
        public int Id { get; set; }
    }
}
