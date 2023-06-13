using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IService<T> where T : class
{
    Task<T?> Get(Id<Order> id);
    Task<Id<T>> Add(T entity);
    Task<Id<T>> Update(T entity);
    Task<Id<T>> Delete(Id<Order> id);
    Task<IEnumerable<T>> GetAll();
}