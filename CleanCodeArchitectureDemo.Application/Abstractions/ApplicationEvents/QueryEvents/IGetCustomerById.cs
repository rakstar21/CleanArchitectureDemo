namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.QueryEvents
{
    public interface IGetCustomerById : IApplicationEvent
    {
        int Id { get; set; }
    }
}