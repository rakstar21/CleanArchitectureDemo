using CleanCodeArchitectureDemo.Db.EFCore.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Db.EFCore.EntityValidations;
using CleanCodeArchitectureDemo.Domain.DataAccess.Repositories;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.DataAccess.UnitOfWork
{
    public class CustomerReadOnlyUnitOfWork : BaseReadOnlyUnitOfWork, ICustomerReadOnlyUnitOfWork, IReadOnlyUnitOfWork
    {
        private readonly IDomainMapper mapper;
        private ICustomerRepository customerRepository;
        private ICustomerContactRepository customerContactRepository;

        public CustomerReadOnlyUnitOfWork(ConnectionSettings connectionSettings, IDomainMapper mapper) : base(connectionSettings)
        {
            customerRepository = new CustomerRepository(dbContext, new CustomerEntityValidator());
            customerContactRepository = new CustomerContactRepository(dbContext, new CustomerContactEntityValidator());
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetCustomerResponse>> GetAllCustomerAsync(CancellationToken cancellationToken = default)
        {
            var customers = await customerRepository.GetAll(cancellationToken);
            return mapper.CustomerMapper.MapEntitiesToResponseModels(customers);
        }

        public async Task<GetCustomerResponse> GetCustomerAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await customerRepository.GetById(id, cancellationToken);
            return mapper.CustomerMapper.MapEntityToResponseModel(customer);
        }

        public async Task<GetCustomerContactResponse> GetCustomerContactById(int Id, CancellationToken cancellationToken = default)
        {
            var contact = await customerContactRepository.GetById(Id, cancellationToken);
            return mapper.CustomerContactMapper.MapEntityToResponseModel(contact);
        }

        public async Task<IEnumerable<GetCustomerContactResponse>> GetCustomerContactsByCustomerId(int customerId, CancellationToken cancellationToken = default)
        {
            var contacts = await customerContactRepository.GetContactsByCustomerId(customerId, cancellationToken);
            return mapper.CustomerContactMapper.MapEntitiesToResponseModels(contacts);
        }
    }
}
