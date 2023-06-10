using Microsoft.Extensions.DependencyInjection;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;
using PizzaSystem.Core.Services;

namespace PizzaSystem.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IService<Order>, OrderService>();
        return services;
    }
}