using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer
{
    public class GetCustomerResponse : IResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<GetCustomerContactResponse> Contacts { get; set; }
    }
}
