using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Persistence;

public class Repository<T> : IRepository<T> where T : IEntity<T>
{
    private readonly Dictionary<ID<T>, T> _memoryEntities = new();
    
    public ID<T> Add(T entity)
    {
        _memoryEntities.Add(entity.Id, entity);
        return entity.Id;
    }

    public ID<T> Update(T entity)
    {
        _memoryEntities[entity.Id] = entity;
        return entity.Id;
    }

    public ID<T> Delete(T entity)
    {
        _memoryEntities.Remove(entity.Id);
        return entity.Id;
    }

    public T? Get(ID<T> id)
    {
        return _memoryEntities.Values.FirstOrDefault(x => x.Id == id);
    }
    
    public IEnumerable<T> GetAll()
    {
        return _memoryEntities.Values;
    }

    public IEnumerable<T> GetAllById(ID<T> id)
    {
        return _memoryEntities.Values.Where(x => x.Id == id);
    }
}