using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents;
using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers
{
    public interface IEventHandler<E> where E : IApplicationEvent
    {
    }
}
