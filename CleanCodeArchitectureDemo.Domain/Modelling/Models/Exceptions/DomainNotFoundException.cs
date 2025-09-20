using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Domain.Modelling.Models.Exceptions
{
    public class DomainNotFoundException<T> : DomainException<T> where T : IDomain
    {
        public DomainNotFoundException() : base($"The specified {typeof(T).Name} was not found.")
        {
        }
    }
}
