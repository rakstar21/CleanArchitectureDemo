using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions.RequestValidations
{
    public abstract class DefaultValidator<T> : IValidator<T> where T : IDomain
    {
        public virtual ValidationResult<T> Validate(T domain)
        {
            return new ValidationResult<T>() 
            {
                IsValid = true,
                ValidationErrors = new List<ValidationError<T>>()
            };
        }
    }
}
