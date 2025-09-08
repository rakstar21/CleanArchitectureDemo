using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer
{
    public class CreateCustomerRequest : IRequest
    {
        public string CustomerName { get; set; }
        public IEnumerable<CreateCustomerContactRequest> Contacts { get; set; }
    }
}
