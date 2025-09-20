using CleanCodeArchitectureDemo.Application.Abstractions;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementaions
{
    public static class ServiceMediator
    {
        public static IServiceCollection AddServiceMediator(this IServiceCollection services, Assembly? assembly = null) 
        {
            assembly ??= Assembly.GetCallingAssembly();

            services.AddScoped<ISender, Sender>();

            RegisterQueryHandlers(services, assembly);
            RegisterCommandHandlers(services, assembly);

            return services;
        }

        private static void RegisterCommandHandlers(IServiceCollection services, Assembly assembly)
        {
            var commanHandlerInterfaceType = typeof(ICommandHandler<,>);

            var commanHandlerTypes = assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .SelectMany(type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == commanHandlerInterfaceType)
                    .Select(i => new { Interface = i, Implementation = type }))
                .ToList();

            foreach (var handler in commanHandlerTypes)
            {
                services.AddScoped(handler.Interface, handler.Implementation);
            }
        }

        private static void RegisterQueryHandlers(IServiceCollection services, Assembly assembly)
        {
            var queryHandlerInterfaceType = typeof(IQueryHandler<,>);

            var queryHandlerTypes = assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .SelectMany(type => type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == queryHandlerInterfaceType)
                    .Select(i => new { Interface = i, Implementation = type }))
                .ToList();

            foreach (var handler in queryHandlerTypes)
            {
                services.AddScoped(handler.Interface, handler.Implementation);
            }
        }
    }
}
