using Mapster;
using PizzaSystem.Application.Controllers;
using PizzaSystem.Application.Requests;
using PizzaSystem.Core.Commands;
using PizzaSystem.Core.Models;
using PizzaSystem.Core.Services;

namespace PizzaSystem.Application;

public static class MappingConfig
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<CreateAlergenRequest, CreateAlergenCommand>.NewConfig()
                                                                     .MapWith(request => new CreateAlergenCommand(
                                                                                  request.Order, 
                                                                                  request.Title,
                                                                                  request.Description));
        TypeAdapterConfig<CreateAlergenCommand, Alergen>.NewConfig()
                                                                     .MapWith(request => new Alergen
                                                                                  {
                                                                                      Order = request.Order,
                                                                                      Title = request.Title,
                                                                                      Description = request.Description
                                                                                  });
        TypeAdapterConfig<UpdateAlergenRequest, UpdateAlergenCommand>.NewConfig()
                                                                     .MapWith(request => new UpdateAlergenCommand(
                                                                                  request.Id,
                                                                                  request.Order,
                                                                                  request.Title,
                                                                                  request.Description));
        TypeAdapterConfig<UpdateAlergenRequest, Alergen>.NewConfig()
                                                        .MapWith(request => new Alergen
                                                        {
                                                            Id          = request.Id,
                                                            Order       = request.Order,
                                                            Title       = request.Title,
                                                            Description = request.Description
                                                        });
    }
}