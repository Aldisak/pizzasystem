using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("menu-items")]
public sealed class MenuItemController : AbstractApiController<MenuItem>
{
    private readonly IService<MenuItem> _menuItemService;

    public MenuItemController(IService<MenuItem> menuItemService, IMediator mediator) : base(mediator)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet("{id:int}")]
    public Task<MenuItem> Get([FromRoute] int id) => _menuItemService.Get(id);

    [HttpPost("{id:int}")]
    public Task<CreatedAtActionResult> Add([FromRoute] int id, [FromBody] MenuItem menuItem) =>
        _menuItemService
            .Add(menuItem)
            .ContinueWith(newItem => CreatedAtAction(nameof(Get), new {id = newItem.Result}, newItem.Result));

    [HttpPut("{id:int}")]
    public Task<MenuItem> Update([FromRoute] int id, [FromBody] MenuItem menuItem) =>
        _menuItemService.Update(menuItem);

    [HttpDelete("{id:int}")]
    public Task<MenuItem> Delete([FromRoute] int id) => _menuItemService.Delete(id);

    [HttpGet]
    public Task<IEnumerable<MenuItem>> GetAll() => _menuItemService.GetAll();
}