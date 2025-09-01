using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.Repositories
{
    public interface ICustomerContactRepository: IRepository<CustomerContactEntity>
    {
        IEnumerable<CustomerContactEntity> GetContactsByCustomerId(int customerId);
    }
}
