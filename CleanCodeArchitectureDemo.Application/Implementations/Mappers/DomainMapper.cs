using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.Mappers
{
    public class DomainMapper : IDomainMapper
    {
        public DomainMapper()
        {
            CustomerMapper = new CustomerMapper();
            CustomerContactMapper = new CustomerContactMapper();
        }
        public ICustomerMapper CustomerMapper { get; private set; }
        public ICustomerContactMapper CustomerContactMapper { get; private set; }
    }
}
