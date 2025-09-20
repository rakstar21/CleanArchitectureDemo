using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.RequestValidations
{
    public class CreateCustomerContactRequestValidator : DefaultValidator<CreateCustomerContactRequest>, IValidator<CreateCustomerContactRequest>
    {
        public override ValidationResult<CreateCustomerContactRequest> Validate(CreateCustomerContactRequest domain)
        {
            var validationResult = base.Validate(domain);

            if (domain.CustomerId < 1) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Invalid CustomerId.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.CustomerId))
            });

            if (domain.FirstName == null || domain.FirstName.Length < 2) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "FirstName must be at least 2 characters long.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.FirstName))
            });

            if (domain.LastName == null || domain.LastName.Length < 2) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "LastName must be at least 2 characters long.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.LastName))
            });

            if (domain.Address == null || domain.Address.Length < 5) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Address must be at least 5 characters long.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.Address))
            });

            if(domain.ContactNumber == null || domain.ContactNumber.Length < 10) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "ContactNumber must be at least 10 characters long.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.ContactNumber))
            });

            if (domain.ContactNumber != null && !domain.ContactNumber.All(c => char.IsDigit(c))) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "ContactNumber must contain only digits.",
                DomainProperty = typeof(CreateCustomerContactRequest).GetProperty(nameof(domain.ContactNumber))
            });

            if (validationResult.ValidationErrors.Any())
            {
                validationResult.IsValid = false;
            }

            return validationResult;
        }
    }
}
