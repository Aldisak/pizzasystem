using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IService<T> where T : IEntity<T>
{
    Task<T?> Get(int id);
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<IEnumerable<T>> GetAll();
}