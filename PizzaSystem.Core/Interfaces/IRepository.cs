namespace PizzaSystem.Core.Interfaces;

public interface IRepository<T>
{
    Task<int> Add(T entity, CancellationToken cancellationToken);
    Task<T> Update(T entity, CancellationToken cancellationToken);
    Task<T> Delete(int id, CancellationToken cancellationToken);
    Task<T?> Get(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
}