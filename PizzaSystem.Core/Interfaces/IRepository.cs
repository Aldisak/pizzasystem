namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    Task<Id<T>> Add(T entity);
    Task<Id<T>> Update(T entity);
    Task<Id<T>> Delete(Id<T> id);
    Task<T?> Get(Id<T> id);
    Task<IEnumerable<T>> GetAll();
}