using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IEntity<T>
{
    int Id { get; }
}

public record struct Id<T>
{
    private int _Id { get; }

    private Id(int id)
    {
        _Id = id;
    }

    public static explicit operator Id<T>(int id) => new(id);
    public static Id<T> Empty => new(0);
}