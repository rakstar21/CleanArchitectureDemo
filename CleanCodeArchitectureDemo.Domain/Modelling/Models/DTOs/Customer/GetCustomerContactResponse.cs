namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer
{
    public class GetCustomerContactResponse: IResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}