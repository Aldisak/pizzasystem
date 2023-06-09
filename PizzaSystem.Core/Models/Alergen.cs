using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Models;

public sealed record Alergen : IEntity<Alergen>
{
    public required ID<Alergen> Id { get; init; }
    public required byte Number { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}