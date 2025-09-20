using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions.EventHandlers.Commands
{
    public class CreateCustomerContactEventHandler : ICommandHandler<ICreateCustomerContactEvent, GetCustomerContactResponse>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly IValidator<CreateCustomerContactRequest> validator;
        private readonly ILogger logger;

        public CreateCustomerContactEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, IValidator<CreateCustomerContactRequest> validator, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.logger = logger;
        }
        public async Task<GetCustomerContactResponse> Handle(ICreateCustomerContactEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(applicationEvent.Request);
            if (validationResult.IsValid)
            {
                unitOfWork.BeginTransaction();
                try
                {
                    var newId = await unitOfWork.CreateCustomerContactAsync(applicationEvent.Request, cancellationToken);
                    await unitOfWork.CommitChangesAsync(cancellationToken);
                    logger.LogInformation($"Succesfully created customer");
                    return await unitOfWork.GetCustomerContactById(newId, cancellationToken);
                }
                catch (Exception ex)
                {
                    await unitOfWork.RollbackChangesAsync(cancellationToken);
                    logger.LogError(ex, $"Error found in {nameof(CreateCustomerContactEventHandler)}");
                    throw;
                }
            }
            else 
            {
                var validationErrors = System.Text.Json.JsonSerializer.Serialize(validationResult.ValidationErrors);
                logger.LogError($"Input errors in {nameof(CreateCustomerContactEventHandler)}: {validationErrors}");

                throw new ArgumentException($"Invalid Arguments");
            }
        }
    }
}
