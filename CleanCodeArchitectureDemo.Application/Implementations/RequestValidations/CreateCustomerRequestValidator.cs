using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.RequestValidations
{
    public class CreateCustomerRequestValidator: DefaultValidator<CreateCustomerRequest>, IValidator<CreateCustomerRequest>
    {
        public override ValidationResult<CreateCustomerRequest> Validate(CreateCustomerRequest domain)
        {
            var validationResult = base.Validate(domain);

            if (string.IsNullOrWhiteSpace(domain.CustomerName) || string.IsNullOrEmpty(domain.CustomerName)) validationResult.ValidationErrors.Add(new ValidationError<CreateCustomerRequest>() 
            {
                ErrorMessage = $"CustomerName is empty",
                DomainName = nameof(CreateCustomerRequest),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            if (validationResult.ValidationErrors.Any())
            {
                validationResult.IsValid = false;
            }

            return validationResult;
        }
    }
}
