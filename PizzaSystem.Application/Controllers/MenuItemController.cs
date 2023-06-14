using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("menu-items")]
public sealed class MenuItemController : AbstractApiController<MenuItem>
{
    private readonly IService<MenuItem> _menuItemService;

    public MenuItemController(IService<MenuItem> menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet("{id:int}")]
    public override Task<MenuItem?> Get([FromRoute] int id) => _menuItemService.Get(id);

    [HttpPost("{id:int}")]
    public override Task<CreatedAtActionResult> Add([FromRoute] int id, [FromBody] MenuItem menuItem) =>
        _menuItemService
            .Add(menuItem)
            .ContinueWith(newItem => CreatedAtAction(nameof(Get), new {id = newItem.Result.Id}, newItem.Result));

    [HttpPut("{id:int}")]
    public override Task<MenuItem> Update([FromRoute] int id, [FromBody] MenuItem menuItem) =>
        _menuItemService.Update(menuItem);

    [HttpDelete("{id:int}")]
    public override Task<MenuItem> Delete([FromRoute] int id) => _menuItemService.Delete(id);

    [HttpGet]
    public override Task<IEnumerable<MenuItem>> GetAll() => _menuItemService.GetAll();
}