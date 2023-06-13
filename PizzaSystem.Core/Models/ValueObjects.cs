namespace PizzaSystem.Core.Models;

public record struct CustomerContact(CustomerName CustomerName, Phone PhoneNumber, Address Address);
public record struct OrderDetails(OrderStatus Status, DeliveryType DeliveryType, DateTime CreatedAt, DateTime? UpdatedAt);
public record struct CustomerName(string FirstName, string LastName);
public record struct Address(string Street, string HouseNumber, string City, string State, string ZipCode);
public record struct Phone(string CountryCode, uint Number);
public enum OrderStatus
{
    Pending,
    Accepted,
    Prepared,
    Delivered,
    Canceled
}
public enum DeliveryType
{
    TakeAway,
    Delivery
}