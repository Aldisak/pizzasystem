using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Persistence;

internal class Repository<T> : IRepository<T> where T : IEntity<T>
{
    private readonly Dictionary<Id<T>, T> _memoryEntities = new();
    
    public Id<T> Add(T entity)
    {
        _memoryEntities.Add(entity.Id, entity);
        return entity.Id;
    }

    public Id<T> Update(T entity)
    {
        _memoryEntities[entity.Id] = entity;
        return entity.Id;
    }

    public Id<T> Delete(Id<T> id)
    {
        _memoryEntities.Remove(id);
        return id;
    }

    public T? Get(Id<T> id)
    {
        return _memoryEntities.Values.FirstOrDefault(x => x.Id == id);
    }
    
    public IEnumerable<T> GetAll()
    {
        return _memoryEntities.Values;
    }
}