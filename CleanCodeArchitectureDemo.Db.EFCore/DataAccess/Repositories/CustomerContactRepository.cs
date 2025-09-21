using CleanCodeArchitectureDemo.Domain.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.Repositories
{
    public class CustomerContactRepository : BaseRepository<CustomerContactEntity>, ICustomerContactRepository, IRepository<CustomerContactEntity>
    {
        public CustomerContactRepository(DbContext dbContext, IValidator<CustomerContactEntity> validator) : base(dbContext, validator)
        {
        }
        public async Task DeleteContactsByCustomerId(int customerId, CancellationToken cancellationToken = default)
        {
            await dbContext.Set<CustomerContactEntity>()
                .Where(cc => cc.CustomerId == customerId)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IEnumerable<CustomerContactEntity>> GetContactsByCustomerId(int customerId, CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<CustomerContactEntity>()
                .Where(cc => cc.CustomerId == customerId)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateCustomerContactsAsync(IEnumerable<CustomerContactEntity> request, CancellationToken cancellationToken = default)
        {
            foreach (var entity in request)
            {
                var validationResult = Validator.Validate(entity);
                if (!validationResult.IsValid) throw new BadRequestException<CustomerContactEntity>(validationResult.ValidationErrors);
            }
            await Task.Run(() => dbContext.UpdateRange(request));
        }
    }
}
