namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
    Task<T?> Get(int id);
    Task<IEnumerable<T>> GetAll();
}