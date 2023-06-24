using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("ingredients")]
public sealed class IngredientController : AbstractApiController<Ingredient>
{
    private readonly IService<Ingredient> _ingredientService;
    
    public IngredientController(IService<Ingredient> ingredientService, IMediator mediator) : base(mediator)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet("{id:int}")]
    public Task<Ingredient?> Get([FromRoute] int id)
        => _ingredientService.Get(id);

    [HttpPost("{id:int}")]
    public Task<CreatedAtActionResult> Add([FromRoute] int id, [FromBody] Ingredient ingredient)
        => _ingredientService.Add(ingredient).ContinueWith(newItem 
                => CreatedAtAction(nameof(Get), new {id = newItem.Result}, newItem.Result));
    
    [HttpPut("{id:int}")]
    public Task<Ingredient> Update([FromRoute] int id, [FromBody] Ingredient ingredient)
        => _ingredientService.Update(ingredient);

    [HttpDelete("{id:int}")]
    public Task<Ingredient> Delete([FromRoute] int id) 
        => _ingredientService.Delete(id);

    [HttpGet]
    public Task<IEnumerable<Ingredient>> GetAll() => _ingredientService.GetAll();
}