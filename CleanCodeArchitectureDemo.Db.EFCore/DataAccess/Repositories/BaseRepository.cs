using CleanCodeArchitectureDemo.Domain.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext dbContext;
        protected readonly IValidator<T> Validator;

        protected BaseRepository(DbContext dbContext, IValidator<T> validator)
        {
            this.dbContext = dbContext;
            this.Validator = validator;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var validationResult = Validator.Validate(entity);
            if (!validationResult.IsValid) throw new BadRequestException<T>(validationResult.ValidationErrors);
            await dbContext.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                var validationResult = Validator.Validate(entity);
                if (!validationResult.IsValid) throw new BadRequestException<T>(validationResult.ValidationErrors);
            }
            await dbContext.AddRangeAsync(entities, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if ((await dbContext.Set<T>().FirstOrDefaultAsync(i => i.Id == entity.Id)) == null) throw new DomainNotFoundException<T>();

            await Task.Run(() => dbContext.Set<T>().Remove(entity), cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            var output = await dbContext.Set<T>().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

            if (output == null) throw new DomainNotFoundException<T>();

            return output;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var validationResult = Validator.Validate(entity);
            if (!validationResult.IsValid) throw new BadRequestException<T>(validationResult.ValidationErrors);

            if (dbContext.Set<T>().FirstOrDefault(i => i.Id == entity.Id) == null) throw new DomainNotFoundException<T>();

            await Task.Run(() => dbContext.Set<T>().Update(entity), cancellationToken);

            return entity;
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                var validationResult = Validator.Validate(entity);
                if (!validationResult.IsValid) throw new BadRequestException<T>(validationResult.ValidationErrors);
                if (dbContext.Set<T>().FirstOrDefault(i => i.Id == entity.Id) == null) throw new DomainNotFoundException<T>();
            }
            await Task.Run(() => dbContext.Set<T>().UpdateRange(entities), cancellationToken);
        }
    }
}
