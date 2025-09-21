using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Mappers
{
    public interface IDomainMapper
    {
        ICustomerMapper CustomerMapper { get; }
        ICustomerContactMapper CustomerContactMapper { get; }
    }
}
