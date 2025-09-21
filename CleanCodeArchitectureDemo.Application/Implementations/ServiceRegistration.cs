using CleanCodeArchitectureDemo.Application.Abstractions;
using CleanCodeArchitectureDemo.Application.Abstractions.EventHandlers;
using CleanCodeArchitectureDemo.Application.Implementations.EventHandlers;
using CleanCodeArchitectureDemo.Application.Implementations.Mappers;
using CleanCodeArchitectureDemo.Application.Implementations.RequestValidations;
using CleanCodeArchitectureDemo.Domain.Modelling.Mappers;
using CleanCodeArchitectureDemo.Domain.Modelling.Models.DTOs.Customer;
using CleanCodeArchitectureDemo.Domain.Modelling.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeArchitectureDemo.Application.Implementations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceMediator(this IServiceCollection services, Assembly? assembly = null) 
        {
            assembly ??= Assembly.GetCallingAssembly();

            services.AddScoped<ISender, Sender>();

            RegisterQueryHandlers(services, assembly);
            RegisterCommandHandlers(services, assembly);

            return services;
        }

        public static IServiceCollection AddDomainMappers(this IServiceCollection services) 
        {
            services.AddScoped<IDomainMapper, DomainMapper>();
            return services;
        }

        public static IServiceCollection AddRequestValidations(this IServiceCollection services) 
        {
            services.AddScoped<IValidator<CreateCustomerContactRequest>, CreateCustomerContactRequestValidator>();
            services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();
            services.AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerRequestValidator>();
            services.AddScoped<IValidator<UpdateCustomerContactRequest>, UpdateCustomerContactRequestValidator>();
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
