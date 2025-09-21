using CleanCodeArchitectureDemo.Domain.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository, IRepository<CustomerEntity>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
