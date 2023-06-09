using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Models;

public sealed record Order : IEntity<Order>
{
    public required ID<Order> Id { get; init; }
    public required List<OrderItem> OrderItems { get; init; }
    public required CustomerContact CustomerContact { get; init; }
    public required decimal Total { get; init; }
    public OrderDetails OrderDetails { get; init; }
}

public sealed record OrderItem : IEntity<OrderItem>
{
    public required ID<OrderItem> Id { get; init; }
    public required MenuItem MenuItem { get; init; }
    public required ushort Quantity { get; init; }
}