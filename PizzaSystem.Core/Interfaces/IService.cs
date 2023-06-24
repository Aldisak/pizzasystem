using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Interfaces;

public interface IService<T> where T : IEntity<T>
{
    Task<T> Get(int id, CancellationToken cancellationToken = default);
    Task<int> Add(T entity, CancellationToken cancellationToken = default);
    Task<T> Update(T entity, CancellationToken cancellationToken = default);
    Task<T> Delete(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
}