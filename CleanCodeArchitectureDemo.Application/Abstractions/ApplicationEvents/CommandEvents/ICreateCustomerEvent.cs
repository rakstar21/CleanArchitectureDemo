using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents
{
    public interface ICreateCustomerEvent : IApplicationEvent
    {
        CreateCustomerRequest Request { get; }
        bool IncludeDependencies { get; }
    }
}