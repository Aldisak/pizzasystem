namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    Id<T> Add(T entity);
    Id<T> Update(T entity);
    Id<T> Delete(Id<T> id);
    T? Get(Id<T> id);
    IEnumerable<T> GetAll();
}