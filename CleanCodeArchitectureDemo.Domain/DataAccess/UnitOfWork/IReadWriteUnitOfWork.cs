using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork
{
    public interface IReadWriteUnitOfWork: IDisposable
    {
        void BeginTransaction();
        Task CommitChangesAsync();
        Task RollbackChangesAsync();
    }
}
