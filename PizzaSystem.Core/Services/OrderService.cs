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

    public async Task<Order?> Get(Id<Order> id)
        => await _orderRepository.Get(id);
    
    public async Task<Id<Order>> Add(Order entity)
        => await _orderRepository.Add(entity);

    public async Task<Id<Order>> Update(Order entity)
    {
        var order = await _orderRepository.Get(entity.Id);
        
        if (order is null) await _orderRepository.Add(entity);
        
        return await _orderRepository.Update(entity);
    }

    public async Task<Id<Order>> Delete(Id<Order> id) 
        => await _orderRepository.Delete(id);

    public async Task<IEnumerable<Order>> GetAll() 
        => await _orderRepository.GetAll();
}