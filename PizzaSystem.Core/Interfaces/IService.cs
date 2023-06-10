using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IService<T> where T : class
{
    Order? Get(Id<Order> id);
    Id<Order> Add(T entity);
    Id<Order> Update(T entity);
    Id<Order> Delete(Id<Order> id);
    IEnumerable<Order> GetAll();
}