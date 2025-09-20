using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork
{
    public interface IReadWriteUnitOfWork: IReadOnlyUnitOfWork
    {
        void BeginTransaction();
        Task CommitChangesAsync(CancellationToken cancellationToken = default);
        Task RollbackChangesAsync(CancellationToken cancellationToken = default);
    }
}
