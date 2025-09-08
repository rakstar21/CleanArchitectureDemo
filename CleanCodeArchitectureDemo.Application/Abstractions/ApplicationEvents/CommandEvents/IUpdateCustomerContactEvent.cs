using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents
{
    public interface IUpdateCustomerContactEvent: IApplicationEvent
    {
        UpdateCustomerContactRequest Request { get; }
    }
}