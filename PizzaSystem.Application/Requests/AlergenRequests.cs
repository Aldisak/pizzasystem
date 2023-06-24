using Mapster;
using PizzaSystem.Core.Commands;

namespace PizzaSystem.Application.Requests;

[AdaptTo(typeof(CreateAlergenCommand))]
public record CreateAlergenRequest(int Order, string Title, string Description);

[AdaptTo(typeof(UpdateAlergenCommand))]
public record UpdateAlergenRequest(int Id, int Order, string Title, string Description);