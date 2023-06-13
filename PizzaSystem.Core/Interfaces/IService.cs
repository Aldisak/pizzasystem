using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IService<T> where T : IEntity<T>
{
    Task<T?> Get(Id<T> id);
    Task<Id<T>> Add(T entity);
    Task<Id<T>> Update(T entity);
    Task<Id<T>> Delete(Id<T> id);
    Task<IEnumerable<T>> GetAll();
}