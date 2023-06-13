using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Persistence.DataStorage.Databases;

public sealed class SqLite : IDatabase<SqLite>
{
    private readonly IConfiguration _configuration;

    public SqLite(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("SqLite");
        return new SqliteConnection(connectionString);
    }
}