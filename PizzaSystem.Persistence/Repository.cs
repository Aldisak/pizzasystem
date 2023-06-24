using Dapper;
using PizzaSystem.Core.Exceptions;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Persistence.DataStorage.Databases;

namespace PizzaSystem.Persistence;

public sealed class Repository<T> : IRepository<T> where T : IEntity<T>
{
    private readonly string _tableName;
    private readonly IDatabase<SqLite> _database;

    public Repository(string tableName, IDatabase<SqLite> database)
    {
        _tableName = tableName;
        _database = database;
    }

    public async Task<int> Add(T entity, CancellationToken cancellationToken = default)
    {    
        using var connection = _database.CreateConnection();
    
        var properties= typeof(T).GetProperties().Where(p => p.Name != "Id");
        var columnNames    = properties.Select(property => $"[{property.Name}]");
        var parameterNames = properties.Select(property => $"@{property.Name}");

        var sql = $"INSERT INTO {_tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", parameterNames)}); SELECT last_insert_rowid();";

        int createdId = await connection.ExecuteScalarAsync<int>(sql, entity);
        return createdId;
    }

    public async Task<T> Update(T entity, CancellationToken cancellationToken = default)
    {
        using var connection = _database.CreateConnection();

        var properties     = typeof(T).GetProperties();
        var columnNames    = properties.Select(property => $"[{property.Name}]");
        var parameterNames = properties.Select(property => $"@{property.Name}");
        
        var existingEntity = await Get(entity.Id, cancellationToken);
        if (existingEntity is null) throw new EntityDoesNotExistException($"Update failed. Entity of type {typeof(T).Name} with id: {entity.Id} does not exist.");

        var sql = $"UPDATE {_tableName} SET {string.Join(", ", columnNames.Zip(parameterNames, (column, parameter) => $"{column} = {parameter}"))} WHERE Id = @Id";
        
        await connection.ExecuteAsync(sql, entity);
        return entity;
    }

    public async Task<T> Delete(int id, CancellationToken cancellationToken = default)
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"DELETE FROM {_tableName} WHERE Id = @Id";
        
        var entity = await Get(id, cancellationToken);
        if (entity is null) throw new EntityDoesNotExistException($"Delete failed. Entity of type {typeof(T).Name} with id: {id} does not exist.");
        
        await connection.ExecuteAsync(sql, new {Id = id});
        return entity!;
    }

    public Task<T?> Get(int id, CancellationToken cancellationToken = default)
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"SELECT * FROM {_tableName} WHERE Id = @Id";
        return connection.QueryFirstOrDefaultAsync<T?>(sql, new {Id = id});
    }
    
    public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"SELECT * FROM {_tableName}";
        return connection.QueryAsync<T>(sql);
    }
}