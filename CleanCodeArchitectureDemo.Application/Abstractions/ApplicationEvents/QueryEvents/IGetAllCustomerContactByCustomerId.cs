
namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents
{
    public interface IGetAllCustomerContactByCustomerIdEvent: IApplicationEvent
    {
        int CustomerId { get; set; }
    }
}