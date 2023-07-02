using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("orders")]
public sealed class OrderController : AbstractApiController<Order>
{
    private readonly IService<Order> _orderService;
    private readonly IHubContext<OrderHub> _hubContext;
    
    public OrderController(IService<Order> orderService, IMediator mediator, IHubContext<OrderHub> hubContext) : base(mediator)
    {
        _orderService    = orderService;
        _hubContext = hubContext;
    }

    [HttpGet("{id:int}")]
    public Task<Order> Get([FromRoute] int id)
        => _orderService.Get(id);

    [HttpPost]
    public async Task<CreatedAtActionResult> Add([FromBody] Order order)
    {
        var result = 60; // await _orderService.Add(order);
        // TODO: Zapracovat ku konkretnimu uzivateli
        await _hubContext.Clients.All.SendAsync("NewOrder", $"New order: {result} - has been placed!");
        return CreatedAtAction(nameof(Get), new {id = result}, result);
    }

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