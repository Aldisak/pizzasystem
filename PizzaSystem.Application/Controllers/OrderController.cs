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
    public override IActionResult Get([FromQuery] Guid id)
    {
        var order = _orderService.Get((Id<Order>) id);
        return Ok(order);
    }

    [HttpPost("order")]
    public override IActionResult Update([FromBody] Order order)
    {
        _orderService.Update(order);
        return Ok(order);
    }

    [HttpDelete("order")]
    public override IActionResult Delete([FromQuery] Guid id)
    {
        return Ok(_orderService.Delete((Id<Order>) id));
    }

    [HttpGet("orders")]
    public override IActionResult GetAll()
    {
        return Ok(_orderService.GetAll());
    }
}