namespace PizzaSystem.Core.Exceptions;

public class EntityDoesNotExistException : Exception
{
    public EntityDoesNotExistException(string message) : base(message) { }
}