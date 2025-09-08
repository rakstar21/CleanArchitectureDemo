using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.DataAccess.UnitOfWork;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions.EventHandlers.Queries
{
    public class GetCustomerByIdEventHandler : IQueryHandler<IGetCustomerById, GetCustomerResponse>
    {
        private readonly ICustomerReadOnlyUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public GetCustomerByIdEventHandler(ICustomerReadOnlyUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task<GetCustomerResponse> Handle(IGetCustomerById applicationEvent, CancellationToken cancellationToken = default)
        {
            try
            {
                return await unitOfWork.GetCustomerAsync(applicationEvent.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error found in {nameof(GetCustomerByIdEventHandler)}");
                throw;
            }
        }
    }
}
