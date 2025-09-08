namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents
{
    public interface IDeleteCustomerContactEvent : IApplicationEvent
    {
        int Id { get; set; }
    }
}