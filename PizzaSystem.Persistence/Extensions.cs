using Microsoft.Extensions.DependencyInjection;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>)); 
        return services;
    }
}