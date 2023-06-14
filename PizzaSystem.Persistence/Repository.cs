using Dapper;
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

    public async Task<T> Add(T entity)
    {    
        using var connection = _database.CreateConnection();
        
        var properties      = typeof(T).GetProperties();
        var columnNames     = properties.Select(property => property.Name);
        var parameterNames  = properties.Select(property => $"@{property.Name}");
        var parameterValues = properties.ToDictionary(property => property.Name, property => property.GetValue(entity));
        
        var sql = $"INSERT INTO {_tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", parameterNames)})";

        await connection.ExecuteAsync(sql, parameterValues);
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        using var connection = _database.CreateConnection();

        var properties      = typeof(T).GetProperties();
        var columnNames     = properties.Select(property => property.Name);
        var parameterValues = properties.ToDictionary(property => property.Name, property => property.GetValue(entity));

        var sql = $"UPDATE {_tableName} SET {string.Join(", ", columnNames.Select(column => $"{column} = @{column}"))} WHERE Id = @Id";

        await connection.ExecuteAsync(sql, parameterValues);
        return entity;
    }

    public async Task<T> Delete(int id)
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"DELETE FROM {_tableName} WHERE Id = @Id";
        var entity = await Get(id);
        // TODO: return Result if entity is null (not found)
        if (entity is not null) await connection.ExecuteAsync(sql, new {Id = id});
        return entity!;
    }

    public Task<T?> Get(int id)
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"SELECT * FROM {_tableName} WHERE Id = @Id";
        return connection.QueryFirstOrDefaultAsync<T?>(sql, new {Id = id});
    }
    
    public Task<IEnumerable<T>> GetAll()
    {
        using var connection = _database.CreateConnection();
        var       sql        = $"SELECT * FROM {_tableName}";
        return connection.QueryAsync<T>(sql);
    }
}