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
    public class CreateCustomerContactEventHandler : ICommandHandler<ICreateCustomerContactEvent, GetCustomerContactResponse>
    {
        private readonly ICustomerReadWriteUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public CreateCustomerContactEventHandler(ICustomerReadWriteUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task<GetCustomerContactResponse> Handle(ICreateCustomerContactEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            unitOfWork.BeginTransaction();
            try
            {
                var newId = await unitOfWork.CreateCustomerContactAsync(applicationEvent.Request);
                await unitOfWork.CommitChangesAsync();
                logger.LogInformation($"Succesfully created customer");
                return await unitOfWork.GetCustomerContactById(newId);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackChangesAsync();
                logger.LogError(ex, $"Error found in {nameof(CreateCustomerContactEventHandler)}");
                throw;
            }
        }
    }
}
