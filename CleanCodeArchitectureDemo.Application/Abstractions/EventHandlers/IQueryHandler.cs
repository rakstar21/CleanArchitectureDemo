using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents;
using CleanCodeArchitectureDemo.Domain.Modelling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers
{
    public interface IQueryHandler<E, R> : IEventHandler<E> where E : IApplicationEvent where R : class
    {
        Task<R> Handle(E applicationEvent, CancellationToken cancellationToken = default);
    }
}
