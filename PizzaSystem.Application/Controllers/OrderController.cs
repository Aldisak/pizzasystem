using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("orders")]
public sealed class OrderController : AbstractApiController<Order>
{
    private readonly IService<Order> _orderService;
    
    public OrderController(IService<Order> orderService, IMediator mediator) : base(mediator)
    {
        _orderService = orderService;
    }

    [HttpGet("{id:int}")]
    public Task<Order> Get([FromRoute] int id)
        => _orderService.Get(id);

    [HttpPost("{id:int}")]
    public Task<CreatedAtActionResult> Add([FromRoute] int id, [FromBody] Order order)
        => _orderService
                .Add(order)
                .ContinueWith(newItem 
                        => CreatedAtAction(nameof(Get), new {id = newItem.Result}, newItem.Result));

    [HttpPut("{id:int}")]
    public Task<Order> Update([FromRoute] int id, [FromBody] Order order)
        => _orderService.Update(order);

    [HttpDelete("{id:int}")]
    public Task<Order> Delete([FromRoute] int id) 
        => _orderService.Delete(id);

    [HttpGet]
    public Task<IEnumerable<Order>> GetAll() 
        => _orderService.GetAll();
}