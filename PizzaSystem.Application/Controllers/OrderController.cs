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
    public override Task<IActionResult> Get([FromQuery] int id)
        => Task.FromResult<IActionResult>(Ok(_orderService.Get(id)));

        [HttpPost("order")]
    public override Task<IActionResult> Update([FromBody] Order order)
        => Task.FromResult<IActionResult>(Ok(_orderService.Update(order)));

    [HttpDelete("order")]
    public override Task<IActionResult> Delete([FromQuery] int id) 
        => Task.FromResult<IActionResult>(Ok(_orderService.Delete(id)));

    [HttpGet("orders")]
    public override Task<IActionResult> GetAll() 
        => Task.FromResult<IActionResult>(Ok(_orderService.GetAll()));
}