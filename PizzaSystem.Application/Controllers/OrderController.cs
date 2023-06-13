using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
public sealed class OrderController : AbstractController<Order>
{
    private readonly IService<Order> _orderService;
    
    public OrderController(IService<Order> orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("order")]
    public override async Task<IActionResult> Get([FromQuery] Guid id)
        => Ok(await _orderService.Get((Id<Order>) id));

        [HttpPost("order")]
    public override async Task<IActionResult> Update([FromBody] Order order)
        => Ok(await _orderService.Update(order));

    [HttpDelete("order")]
    public override async Task<IActionResult> Delete([FromQuery] Guid id) 
        => Ok(await _orderService.Delete((Id<Order>) id));

    [HttpGet("orders")]
    public override async Task<IActionResult> GetAll() => Ok(await _orderService.GetAll());
}