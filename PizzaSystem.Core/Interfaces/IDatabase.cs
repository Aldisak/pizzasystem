using System.Data;

namespace PizzaSystem.Core.Interfaces;

public interface IDatabase<out T>
{
    public IDbConnection CreateConnection();
}