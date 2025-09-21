using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.UnitOfWork
{
    public abstract class BaseReadWriteUnitOfWork : BaseReadOnlyUnitOfWork, IReadWriteUnitOfWork
    {
        protected IDbContextTransaction? dbContextTransaction;
        public BaseReadWriteUnitOfWork(ConnectionSettings connectionSettings): base(new AppDbContext(connectionSettings, false))
        {
            
        }

        public void BeginTransaction()
        {
            dbContextTransaction = dbContext.Database.BeginTransaction();
        }

        public async Task CommitChangesAsync(CancellationToken cancellationToken = default)
        {
            if (dbContextTransaction == null) throw new InvalidOperationException("Transaction has not been started. Call BeginTransaction method first.");
            await dbContext.SaveChangesAsync(cancellationToken);
            await dbContextTransaction.CommitAsync(cancellationToken);

            dbContext.Dispose();
            
        }

        public async Task RollbackChangesAsync(CancellationToken cancellationToken = default)
        {
            if (dbContextTransaction == null) throw new InvalidOperationException("Transaction has not been started. Call BeginTransaction method first.");
            await dbContextTransaction.RollbackAsync(cancellationToken);
        }

        public new void Dispose()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Dispose();
                dbContextTransaction = null;
            }

            base.Dispose();
        }
    }
}
