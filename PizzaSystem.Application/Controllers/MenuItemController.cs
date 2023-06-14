using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
public sealed class MenuItemController : AbstractController<MenuItem>
{
    private readonly IService<MenuItem> _menuItemService;
    
    public MenuItemController(IService<MenuItem> menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet("menu-item")]
    public override Task<IActionResult> Get([FromQuery] int id)
        => Task.FromResult<IActionResult>(Ok(_menuItemService.Get(id)));

        [HttpPost("menu-item")]
    public override Task<IActionResult> Update([FromBody] MenuItem menuItem)
        => Task.FromResult<IActionResult>(Ok(_menuItemService.Update(menuItem)));

    [HttpDelete("menu-item")]
    public override Task<IActionResult> Delete([FromQuery] int id) 
        => Task.FromResult<IActionResult>(Ok(_menuItemService.Delete(id)));

    [HttpGet("menu-items")]
    public override Task<IActionResult> GetAll() 
        => Task.FromResult<IActionResult>(Ok(_menuItemService.GetAll()));
}