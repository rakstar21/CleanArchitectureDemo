using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations.RequestValidations
{
    public abstract class DefaultValidator<T> : IValidator<T> where T : IDomain
    {
        protected readonly ValidationResult<T> ValidationResult;
        protected DefaultValidator()
        {
            ValidationResult = CreateDefaultValidationResult();
        }
        public virtual ValidationResult<T> Validate(T domain)
        {
            if (ValidationResult.ValidationErrors.Any())
            {
                ValidationResult.IsValid = false;
            }

            return ValidationResult;
        }

        protected ValidationResult<T> CreateDefaultValidationResult()
        {
            return new ValidationResult<T>()
            {
                IsValid = true,
                ValidationErrors = new List<ValidationError<T>>()
            };
        }
    }
}
