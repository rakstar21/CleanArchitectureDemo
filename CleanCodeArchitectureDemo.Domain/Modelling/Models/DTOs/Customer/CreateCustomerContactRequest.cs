namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer
{
    public class CreateCustomerContactRequest : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}