using CleanCodeArchitectureDemo.Application.Abstractions;
using CleanCodeArchitectureDemo.Application.Abstractions.ApplicationEvents;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions
{
    public class Sender : ISender
    {
        private readonly IServiceProvider service;

        public Sender(IServiceProvider serviceProvider)
        {
            this.service = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IQueryHandler<IApplicationEvent, TResponse> request, CancellationToken cancellationToken = default) where TResponse : class
        {
            var handlerType = typeof(IQueryHandler<, >).MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = service.GetService(handlerType);

            return await handler.Handle((dynamic)request, cancellationToken);
        }

        public async Task<TResponse> Send<TResponse>(ICommandHandler<IApplicationEvent, TResponse> request, CancellationToken cancellationToken = default) where TResponse : class
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = service.GetService(handlerType);
            return await handler.Handle((dynamic)request, cancellationToken);
        }

        public async Task Send(ICommandHandler<IApplicationEvent> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(request.GetType());
            dynamic handler = service.GetService(handlerType);
            await handler.Handle((dynamic)request, cancellationToken);
        }
    }
}
