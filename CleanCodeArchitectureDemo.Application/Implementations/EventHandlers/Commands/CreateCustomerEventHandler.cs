using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.EventHandlers.Commands
{
    public class CreateCustomerEventHandler : ICommandHandler<ICreateCustomerEvent, GetCustomerResponse>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly IValidator<CreateCustomerRequest> validator;
        private readonly ILogger logger;

        public CreateCustomerEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, IValidator<CreateCustomerRequest> validator, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.logger = logger;
        }
        public async Task<GetCustomerResponse> Handle(ICreateCustomerEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(applicationEvent.Request);
            if(validationResult.IsValid)
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
                    logger.LogError(ex, $"Error found in {nameof(CreateCustomerEventHandler)}");
                    throw;
                }
            }
            else 
            {
                var validationErrors = System.Text.Json.JsonSerializer.Serialize(validationResult.ValidationErrors);
                logger.LogError($"Input errors in {nameof(CreateCustomerEventHandler)}: {validationErrors}");
                throw new BadRequestException<CreateCustomerRequest>(validationResult.ValidationErrors);
            }
        }
    }
}
