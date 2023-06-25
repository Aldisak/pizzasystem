using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PizzaSystem.Core.Commands;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;
using PizzaSystem.Core.Services;

namespace PizzaSystem.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<>), typeof(Service<>));
        
        // Register handlers dynamically from the assembly PizzaSystem.Core according to the IRequestHandler<,> interface
        var assembly = Assembly.GetExecutingAssembly();
        foreach (var type in assembly.GetTypes())
        {
            if (!type.IsClass || type.IsAbstract) continue;
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                {
                    services.AddScoped(@interface, type);
                }
            }
        }
        
        return services;
    }
}