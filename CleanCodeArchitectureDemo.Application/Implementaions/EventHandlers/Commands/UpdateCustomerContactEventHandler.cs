using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
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
        private readonly ILogger logger;

        public UpdateCustomerContactEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task Handle(IUpdateCustomerContactEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            unitOfWork.BeginTransaction();
            try
            {
                await unitOfWork.UpdateCustomerContactAsync(applicationEvent.Request);
                await unitOfWork.CommitChangesAsync();
                logger.LogInformation($"Updated customer contact with Id { applicationEvent.Request.Id }");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackChangesAsync();
                logger.LogError(ex, $"Error found in {nameof(UpdateCustomerContactEventHandler)}");
                throw;
            }
        }
    }
}
