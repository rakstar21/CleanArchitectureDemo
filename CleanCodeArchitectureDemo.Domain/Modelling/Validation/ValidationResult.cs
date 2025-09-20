using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Validation
{
    public class ValidationResult<T> where T : IDomain
    {
        public bool IsValid { get; set; }
        public IList<ValidationError<T>> ValidationErrors { get; set; } = new List<ValidationError<T>>();
    }
}