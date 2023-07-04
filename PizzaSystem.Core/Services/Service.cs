using PizzaSystem.Core.Exceptions;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Services;
internal sealed class Service<T> : IService<T> where T : IEntity<T>
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> Get(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.Get(id, cancellationToken);
        if (entity == null) 
            throw new EntityDoesNotExistException($"Requested entity of type {typeof(T).Name} with id {id} does not exist.");
        return entity;
    }
    
    public Task<int> Add(T entity, CancellationToken cancellationToken = default)
        => _repository.Add(entity, cancellationToken);

    public Task<T> Update(T entity, CancellationToken cancellationToken = default) 
        => _repository.Update(entity, cancellationToken);

    public Task<T> Delete(int id, CancellationToken cancellationToken = default) 
        => _repository.Delete(id, cancellationToken);

    public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default) 
        => _repository.GetAll(cancellationToken);
}