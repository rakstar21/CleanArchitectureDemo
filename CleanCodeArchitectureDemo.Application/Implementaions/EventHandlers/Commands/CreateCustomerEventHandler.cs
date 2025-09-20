using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions.EventHandlers.Commands
{
    public class CreateCustomerEventHandler : ICommandHandler<ICreateCustomerEvent, GetCustomerResponse>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public CreateCustomerEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task<GetCustomerResponse> Handle(ICreateCustomerEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var newId = await unitOfWork.CreateCustomerAsync(applicationEvent.Request, cancellationToken);
                if (applicationEvent.IncludeDependencies && applicationEvent.Request.Contacts.Any()) 
                {
                    IEnumerable<CreateCustomerContactRequest> contacts = applicationEvent.Request.Contacts.ToList();
                    foreach (var customerContact in contacts) 
                    {
                        customerContact.CustomerId = newId;
                    }
                    await unitOfWork.CreateCustomerContactsAsync(contacts, cancellationToken);
                }
                await unitOfWork.CommitChangesAsync(cancellationToken);
                logger.LogInformation($"Succesfully created customer");
                return await unitOfWork.GetCustomerAsync(newId, cancellationToken);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackChangesAsync(cancellationToken);
                logger.LogError(ex, $"Error found in { nameof(CreateCustomerEventHandler) }");
                throw;
            }
        }
    }
}
