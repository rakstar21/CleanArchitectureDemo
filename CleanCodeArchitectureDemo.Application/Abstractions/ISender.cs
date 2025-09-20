using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Abstractions
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IQueryHandler<IApplicationEvent, TResponse> request, CancellationToken cancellationToken = default) where TResponse : class;
        Task<TResponse> Send<TResponse>(ICommandHandler<IApplicationEvent, TResponse> request, CancellationToken cancellationToken = default) where TResponse : class;
        Task Send(ICommandHandler<IApplicationEvent> request, CancellationToken cancellationToken = default);
    }
}