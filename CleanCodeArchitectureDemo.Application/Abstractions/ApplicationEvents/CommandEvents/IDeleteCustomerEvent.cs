namespace CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents.CommandEvents
{
    public interface IDeleteCustomerEvent: IApplicationEvent
    {
        int Id { get; set; }
    }
}