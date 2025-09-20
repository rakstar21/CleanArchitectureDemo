
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions
{
    public class BadRequestException<T> : DomainException<T> where T : IDomain
    {
        public BadRequestException(IEnumerable<ValidationError<T>> validationErrors) : base($"Invalid { nameof(T) }. See validation errors for more details")
        {
            ValidationErrors = validationErrors;
        }

        public IEnumerable<ValidationError<T>> ValidationErrors { get; private set; }
    }
}