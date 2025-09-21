using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
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
            if (string.IsNullOrWhiteSpace(domain.CustomerName) || string.IsNullOrEmpty(domain.CustomerName)) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerRequest>() 
            {
                ErrorMessage = $"CustomerName is empty",
                DomainName = nameof(CreateCustomerRequest),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            if (domain.CustomerName != null && domain.CustomerName.Length > 100) ValidationResult.ValidationErrors.Add(new ValidationError<CreateCustomerRequest>()
            {
                ErrorMessage = "CustomerName must not be more than 100 characters long.",
                DomainName = nameof(CustomerEntity),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            return base.Validate(domain);
        }
    }
}
