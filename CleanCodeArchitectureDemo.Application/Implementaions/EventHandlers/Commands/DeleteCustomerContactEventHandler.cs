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
    public class DeleteCustomerContactEventHandler : ICommandHandler<IDeleteCustomerContactEvent>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public DeleteCustomerContactEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task Handle(IDeleteCustomerContactEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            unitOfWork.BeginTransaction();
            try
            {
                await unitOfWork.DeleteCustomerContactAsync(applicationEvent.Id);
                await unitOfWork.CommitChangesAsync();
                logger.LogInformation($"Delete customer with Customer Contact Id { applicationEvent.Id }");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackChangesAsync();
                logger.LogError(ex, $"Error found in {nameof(DeleteCustomerContactEventHandler)}");
                throw;
            }
        }
    }
}
