
namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents
{
    public interface IGetCustomerContactByIdEvent: IApplicationEvent
    {
        int CustomerId { get; set; }
    }
}