namespace PizzaSystem.Core.Models;
public sealed record Ingredient : IEntity<Ingredient>
{
    public required ID<Ingredient> Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
}