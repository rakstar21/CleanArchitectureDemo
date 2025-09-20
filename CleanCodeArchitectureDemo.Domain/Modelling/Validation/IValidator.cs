using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Validation
{
    public interface IValidator<T> where T : IDomain
    {
        ValidationResult<T> Validate(T domain);
    }
}
