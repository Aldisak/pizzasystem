using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Models;

public sealed record MenuItem : IEntity<MenuItem>
{
    public required Id<MenuItem> Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public required List<Ingredient> Ingredients { get; init; }
    public required List<Alergen> Alergens { get; init; }
    public required decimal Price { get; init; }
}