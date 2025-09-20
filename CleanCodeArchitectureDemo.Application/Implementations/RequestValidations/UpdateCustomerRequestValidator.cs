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
    public class UpdateCustomerRequestValidator: DefaultValidator<UpdateCustomerRequest>, IValidator<UpdateCustomerRequest>
    {
        public override ValidationResult<UpdateCustomerRequest> Validate(UpdateCustomerRequest domain)
        {
            var validationResult = base.Validate(domain);

            if (string.IsNullOrWhiteSpace(domain.CustomerName) || string.IsNullOrEmpty(domain.CustomerName)) validationResult.ValidationErrors.Add(new ValidationError<UpdateCustomerRequest>() 
            {
                ErrorMessage = $"CustomerName is empty",
                DomainProperty = typeof(UpdateCustomerRequest).GetProperty(nameof(domain.CustomerName))
            });

            if (domain.Id < 1) validationResult.ValidationErrors.Add(new ValidationError<UpdateCustomerRequest>()
            {
                ErrorMessage = "Invalid Id.",
                DomainProperty = typeof(UpdateCustomerRequest).GetProperty(nameof(domain.Id))
            });

            if (validationResult.ValidationErrors.Any())
            {
                validationResult.IsValid = false;
            }

            return validationResult;
        }
    }
}
