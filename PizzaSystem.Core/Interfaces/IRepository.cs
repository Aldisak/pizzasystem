using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    ID<T> Add(T entity);
    ID<T> Update(T entity);
    ID<T> Delete(T entity);
    T Get(ID<T> id);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAllById(ID<T> id);
}