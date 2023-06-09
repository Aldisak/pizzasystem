using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Models;

public sealed record Alergen : IEntity<Alergen>
{
    public int Id { get; init; }
    public required long Order { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}