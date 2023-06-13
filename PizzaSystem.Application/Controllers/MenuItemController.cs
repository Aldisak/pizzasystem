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
    public override async Task<IActionResult> Get([FromQuery] Guid id)
        => Ok(await _menuItemService.Get((Id<MenuItem>) id));

        [HttpPost("menu-item")]
    public override async Task<IActionResult> Update([FromBody] MenuItem menuItem)
        => Ok(await _menuItemService.Update(menuItem));

    [HttpDelete("menu-item")]
    public override async Task<IActionResult> Delete([FromQuery] Guid id) 
        => Ok(await _menuItemService.Delete((Id<MenuItem>) id));

    [HttpGet("menu-items")]
    public override async Task<IActionResult> GetAll() 
        => Ok(await _menuItemService.GetAll());
}