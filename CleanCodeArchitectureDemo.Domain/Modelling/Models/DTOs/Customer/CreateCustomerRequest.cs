using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer
{
    public class CreateCustomerRequest
    {
        public string CustomerName { get; set; }
        IEnumerable<CreateCustomerContactRequest> Contacts { get; set; }
    }
}
