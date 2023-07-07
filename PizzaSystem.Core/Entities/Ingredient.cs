using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Entities;
public sealed record Ingredient : IEntity<Ingredient>
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
}