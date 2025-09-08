using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;

namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents
{
    public interface ICreateCustomerContactEvent: IApplicationEvent
    {
        CreateCustomerContactRequest Request { get; }
    }
}