using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Services;

internal sealed class OrderService : IService<Order>
{
    private readonly IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order? Get(Id<Order> id)
    {
        return _orderRepository.Get(id);
    }

    public Id<Order> Add(Order entity)
    {
        return _orderRepository.Add(entity);
    }

    public Id<Order> Update(Order entity)
    {
        return _orderRepository.Update(entity);
    }

    public Id<Order> Delete(Id<Order> id)
    {
        return _orderRepository.Delete(id);
    }

    public IEnumerable<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }
}