using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Validation
{
    public class ValidationError<T> where T : IDomain
    {
        public string ErrorMessage { get; set; } = "";
        public string DomainName { get; set; } = nameof(T);
        public string? DomainProperty { get; set; }
        public object? PropertyValue { get; set; }
    }
}
