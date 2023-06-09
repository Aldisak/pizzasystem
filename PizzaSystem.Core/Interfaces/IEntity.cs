namespace PizzaSystem.Core.Interfaces;

public interface IEntity<T>
{
    ID<T> Id { get; }
}

public record struct ID<T>
{
    private Guid _Id { get; }

    private ID(Guid id)
    {
        _Id = id;
    }

    public static explicit operator ID<T>(Guid id) => new(id);
    public static ID<T> Empty => new(Guid.Empty);
}