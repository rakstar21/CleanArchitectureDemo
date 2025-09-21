using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CleanCodeArchitectureDemo.Application.Implementations.RequestValidations
{
    public class UpdateCustomerRequestValidator: DefaultValidator<UpdateCustomerRequest>, IValidator<UpdateCustomerRequest>
    {
        public override ValidationResult<UpdateCustomerRequest> Validate(UpdateCustomerRequest domain)
        {
            if (string.IsNullOrWhiteSpace(domain.CustomerName) || string.IsNullOrEmpty(domain.CustomerName)) ValidationResult.ValidationErrors.Add(new ValidationError<UpdateCustomerRequest>() 
            {
                ErrorMessage = $"CustomerName is empty",
                DomainName = nameof(UpdateCustomerRequest),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            if (domain.CustomerName != null && domain.CustomerName.Length > 100) ValidationResult.ValidationErrors.Add(new ValidationError<UpdateCustomerRequest>()
            {
                ErrorMessage = "CustomerName must not be more than 100 characters long.",
                DomainName = nameof(UpdateCustomerRequest),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            if (domain.Id < 1) ValidationResult.ValidationErrors.Add(new ValidationError<UpdateCustomerRequest>()
            {
                ErrorMessage = "Invalid Id.",
                DomainName = nameof(UpdateCustomerRequest),
                DomainProperty = nameof(domain.Id),
                PropertyValue = domain.Id
            });

            return base.Validate(domain);
        }
    }
}
