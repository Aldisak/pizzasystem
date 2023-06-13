using System.Data.SQLite;
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
        return services;
    }
}