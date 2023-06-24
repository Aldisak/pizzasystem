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
        
        // Register handlers dynamically from the assembly where the handlers are defined
        // Commands
        services.AddScoped<IRequestHandler<CreateAlergenCommand, int>, CreateAlergenCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateAlergenCommand, Alergen>, UpdateAlergenCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteAlergenCommand, Alergen>, DeleteAlergenCommandHandler>();
        // Queries
        services.AddScoped<IRequestHandler<GetAlergenQuery, Alergen>, GetAlergenQueryHandler>();
        services.AddScoped<IRequestHandler<GetAlergensQuery, IEnumerable<Alergen>>, GetAlergensQueryHandler>();
        
        return services;
    }
}