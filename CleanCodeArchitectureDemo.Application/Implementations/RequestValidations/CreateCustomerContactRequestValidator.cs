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
            if (domain.CustomerId < 1) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Invalid CustomerId.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.CustomerId),
                PropertyValue = domain.CustomerId
            });

            if (domain.FirstName == null || domain.FirstName.Length < 2) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "FirstName must be at least 2 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.FirstName),
                PropertyValue = domain.FirstName
            });

            if (domain.FirstName == null || domain.FirstName.Length > 50) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "FirstName must not be more than 50 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.FirstName),
                PropertyValue = domain.FirstName
            });

            if (domain.LastName == null || domain.LastName.Length < 2) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "LastName must be at least 2 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.LastName),
                PropertyValue = domain.LastName
            });

            if (domain.LastName == null || domain.LastName.Length > 50) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "LastName must not be more than 50 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.LastName),
                PropertyValue = domain.LastName
            });

            if (domain.Address == null || domain.Address.Length < 5) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Address must be at least 5 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.Address),
                PropertyValue = domain.Address
            });

            if (domain.Address == null || domain.Address.Length > 500) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Address must not be more than 500 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.Address),
                PropertyValue = domain.Address
            });

            if (domain.ContactNumber == null || domain.ContactNumber.Length < 10) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "ContactNumber must be at least 10 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.ContactNumber),
                PropertyValue = domain.ContactNumber
            });

            if (domain.ContactNumber == null || domain.ContactNumber.Length > 25) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "Address must not be more than 25 characters long.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.ContactNumber),
                PropertyValue = domain.ContactNumber
            });

            if (domain.ContactNumber != null && !domain.ContactNumber.All(c => char.IsDigit(c))) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerContactRequest>()
            {
                ErrorMessage = "ContactNumber must contain only digits.",
                DomainName = nameof(CreateCustomerContactRequest),
                DomainProperty = nameof(domain.ContactNumber),
                PropertyValue = domain.ContactNumber
            });

            return ValidationResult;
        }
    }
}
