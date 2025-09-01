using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities
{
    public class CustomerEntity: BaseEntity
    {
        public string CustomerName { get; set; }
        public virtual IEnumerable<CustomerContactEntity> Contacts { get; set; }
    }
}
