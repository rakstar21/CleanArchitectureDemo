using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities
{
    public abstract class BaseEntity: IDomain
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
