using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions
{
    public abstract class DomainException<T> : Exception where T : IDomain
    {
        protected DomainException(string message) : base(message) { }
    }
}
