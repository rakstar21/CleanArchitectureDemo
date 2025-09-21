using CleanCodeArchitectureDemo.Domain.Modelling.Models.DbEntities;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Db.EFCore.EntityValidations
{
    public class CustomerEntityValidator : DefaultValidator<CustomerEntity>
    {
        public override ValidationResult<CustomerEntity> Validate(CustomerEntity domain)
        {
            if (string.IsNullOrWhiteSpace(domain.CustomerName) || string.IsNullOrEmpty(domain.CustomerName)) ValidationResult.ValidationErrors.Add(new ValidationError<CustomerEntity>()
            {
                ErrorMessage = $"CustomerName is required",
                DomainName = nameof(CustomerEntity),
                DomainProperty = nameof(domain.CustomerName),
                PropertyValue = domain.CustomerName
            });

            if (domain.CustomerName != null && domain.CustomerName.Length > 100) ValidationResult.ValidationErrors.Add(new ValidationError<CustomerEntity>()
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
