using Microsoft.Extensions.DependencyInjection;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;
using PizzaSystem.Persistence.DataStorage.Databases;

namespace PizzaSystem.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepository<Order>, Repository<Order>>(
            x => new Repository<Order>("Orders", x.GetService<SqLite>()!));
        services.AddSingleton<IRepository<Alergen>, Repository<Alergen>>(
            x => new Repository<Alergen>("Alergen", x.GetService<SqLite>()!));
        services.AddSingleton<IRepository<Ingredient>, Repository<Ingredient>>(
            x => new Repository<Ingredient>("Ingredient", x.GetService<SqLite>()!));
        services.AddSingleton<IRepository<MenuItem>, Repository<MenuItem>>(
            x => new Repository<MenuItem>("MenuItem", x.GetService<SqLite>()!));
        return services;
    }
}