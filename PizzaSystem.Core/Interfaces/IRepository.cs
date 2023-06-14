namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    Task<int> Add(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(int id);
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
}