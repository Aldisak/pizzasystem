using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Services;

internal sealed class Service<T> : IService<T> where T : IEntity<T>
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T?> Get(int id)
        => await _repository.Get(id);
    
    public async Task<int> Add(T entity)
        => await _repository.Add(entity);

    public async Task<int> Update(T entity)
    {
        var result = await _repository.Get(entity.Id);
        
        if (result is null) await _repository.Add(entity);
        
        return await _repository.Update(entity);
    }

    public async Task<int> Delete(int id) 
        => await _repository.Delete(id);

    public async Task<IEnumerable<T>> GetAll() 
        => await _repository.GetAll();
}