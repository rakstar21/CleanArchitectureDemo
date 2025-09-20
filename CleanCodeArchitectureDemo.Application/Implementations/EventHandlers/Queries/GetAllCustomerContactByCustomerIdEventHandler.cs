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

namespace CleanCodeArchitectureDemo.Application.Implementations.EventHandlers.Queries
{
    public class GetAllCustomerContactByCustomerIdEventHandler : IQueryHandler<IGetAllCustomerContactByCustomerIdEvent, IEnumerable<GetCustomerContactResponse>>
    {
        private readonly ICustomerReadOnlyUnitOfWork unitOfWork;
        private readonly ILogger logger;

        public GetAllCustomerContactByCustomerIdEventHandler(ICustomerReadOnlyUnitOfWork unitOfWork, ILogger logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }
        public async Task<IEnumerable<GetCustomerContactResponse>> Handle(IGetAllCustomerContactByCustomerIdEvent applicationEvent, CancellationToken cancellationToken = default)
        {
            try
            {
                return await unitOfWork.GetCustomerContactsByCustomerId(applicationEvent.CustomerId, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error found in {nameof(GetAllCustomerContactByCustomerIdEventHandler)}");
                throw;
            }
        }
    }
}
