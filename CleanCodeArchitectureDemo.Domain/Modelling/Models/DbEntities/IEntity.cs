using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities
{
    public interface IEntity: IDomain
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
