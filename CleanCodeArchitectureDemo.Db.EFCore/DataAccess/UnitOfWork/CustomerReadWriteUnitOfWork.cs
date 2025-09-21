using CleanCodeArchitectureDemo.Db.EFCore.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.UnitOfWork
{
    public class CustomerReadWriteUnitOfWork : BaseReadWriteUnitOfWork, ICustomerReadWriteUnitOfWork, IReadWriteUnitOfWork
    {
        private readonly IDomainMapper mapper;
        private readonly CustomerReadOnlyUnitOfWork readUow;
        private ICustomerRepository customerRepository;
        private ICustomerContactRepository customerContactRepository;

        public CustomerReadWriteUnitOfWork(ConnectionSettings connectionSettings, IDomainMapper mapper) : base(connectionSettings)
        {
            readUow = new CustomerReadOnlyUnitOfWork(connectionSettings, mapper);
            customerRepository = new CustomerRepository(dbContext);
            customerContactRepository = new CustomerContactRepository(dbContext);
            this.mapper = mapper;
        }

        public async Task<int> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerMapper.MapRequestModelToEntity(request);
            await customerRepository.AddAsync(model);
            return model.Id;
        }

        public async Task<int> CreateCustomerContactAsync(CreateCustomerContactRequest request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerContactMapper.MapRequestModelToEntity(request);
            await customerContactRepository.AddAsync(model);
            return model.Id;
        }

        public async Task CreateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerContactMapper.MapRequestModelsToEntities(request);
            await customerContactRepository.AddRangeAsync(model);
        }

        public async Task DeleteCustomerAsync(int customerId, CancellationToken cancellationToken = default)
        {
            var customerEntity = await customerRepository.GetById(customerId, cancellationToken);
            await customerRepository.DeleteAsync(customerEntity);
        }

        public async Task DeleteCustomerContactAsync(int customerId, CancellationToken cancellationToken = default)
        {
            await customerContactRepository.DeleteContactsByCustomerId(customerId, cancellationToken);
        }

        public async Task<IEnumerable<GetCustomerResponse>> GetAllCustomerAsync(CancellationToken cancellationToken = default)
        {
            return await readUow.GetAllCustomerAsync(cancellationToken);
        }

        public async Task<GetCustomerResponse> GetCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            return await readUow.GetCustomerAsync(id, cancellationToken);
        }

        public async Task<GetCustomerContactResponse> GetCustomerContactById(int Id, CancellationToken cancellationToken = default)
        {
            return await readUow.GetCustomerContactById(Id, cancellationToken);
        }

        public async Task<IEnumerable<GetCustomerContactResponse>> GetCustomerContactsByCustomerId(int customerId, CancellationToken cancellationToken = default)
        {
            return await readUow.GetCustomerContactsByCustomerId(customerId, cancellationToken);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerMapper.MapRequestModelToEntity(request);
            await customerRepository.UpdateAsync(model);
        }

        public async Task UpdateCustomerContactAsync(UpdateCustomerContactRequest request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerContactMapper.MapRequestModelToEntity(request);
            await customerContactRepository.UpdateAsync(model);
        }

        public async Task UpdateCustomerContactsAsync(IEnumerable<CreateCustomerContactRequest> request, CancellationToken cancellationToken = default)
        {
            var model = mapper.CustomerContactMapper.MapRequestModelsToEntities(request);
            await customerContactRepository.UpdateCustomerContactsAsync(model, cancellationToken);
        }
    }
}
