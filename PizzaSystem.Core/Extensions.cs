using Microsoft.Extensions.DependencyInjection;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Services;

namespace PizzaSystem.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<>), typeof(Service<>));
        return services;
    }
}