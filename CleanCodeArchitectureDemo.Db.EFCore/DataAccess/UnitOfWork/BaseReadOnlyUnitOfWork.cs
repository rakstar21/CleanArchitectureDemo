using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.UnitOfWork
{
    public abstract class BaseReadOnlyUnitOfWork : IReadOnlyUnitOfWork
    {
        protected readonly DbContext dbContext;

        public BaseReadOnlyUnitOfWork(ConnectionSettings connectionSettings)
        {
            this.dbContext = new AppDbContext(connectionSettings, true);
        }

        protected BaseReadOnlyUnitOfWork(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }

        public virtual void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
