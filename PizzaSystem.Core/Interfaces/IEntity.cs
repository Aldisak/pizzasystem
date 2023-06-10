using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IEntity<T>
{
    Id<T> Id { get; }
}

public record struct Id<T>
{
    private Guid _Id { get; }

    private Id(Guid id)
    {
        _Id = id;
    }

    public static explicit operator Id<T>(Guid id) => new(id);
    public static Id<T> Empty => new(Guid.Empty);
}