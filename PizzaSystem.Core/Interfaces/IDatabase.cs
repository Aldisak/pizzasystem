using System.Data;
using System.Data.SQLite;

namespace PizzaSystem.Core.Interfaces;

public interface IDatabase<out T>
{
    public IDbConnection CreateConnection();
}