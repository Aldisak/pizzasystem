namespace PizzaSystem.Application.Requests;

public record CreateAlergenRequest(int Order, string Title, string Description);
public record UpdateAlergenRequest(int Id, int Order, string Title, string Description);