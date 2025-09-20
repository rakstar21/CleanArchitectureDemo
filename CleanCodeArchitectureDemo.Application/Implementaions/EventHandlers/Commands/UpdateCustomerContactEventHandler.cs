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
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions.EventHandlers.Commands
{
    public class UpdateCustomerContactEventHandler : ICommandHandler<IUpdateCustomerContactEvent>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly IValidator<UpdateCustomerContactRequest> validator;
        private readonly ILogger logger;

        public UpdateCustomerContactEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, IValidator<UpdateCustomerContactRequest> validator, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.logger = logger;
        }
        public async Task Handle(IUpdateCustomerContactEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            var validationResult = validator.Validate(applicationEvent.Request);
            if (validationResult.IsValid)
            {
                unitOfWork.BeginTransaction();
                try
                {
                    await unitOfWork.UpdateCustomerContactAsync(applicationEvent.Request, cancellationToken);
                    await unitOfWork.CommitChangesAsync(cancellationToken);
                    logger.LogInformation($"Updated customer contact with Id {applicationEvent.Request.Id}");
                }
                catch (Exception ex)
                {
                    await unitOfWork.RollbackChangesAsync(cancellationToken);
                    logger.LogError(ex, $"Error found in {nameof(UpdateCustomerContactEventHandler)}");
                    throw;
                }
            }
            else
            {
                var validationErrors = System.Text.Json.JsonSerializer.Serialize(validationResult.ValidationErrors);
                logger.LogError($"Input errors in {nameof(UpdateCustomerContactEventHandler)}: {validationErrors}");
                throw new ArgumentException($"Invalid Arguments");
            }
        }
    }
}
