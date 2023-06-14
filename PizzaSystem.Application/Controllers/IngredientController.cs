using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
public sealed class IngredientController : AbstractController<Ingredient>
{
    private readonly IService<Ingredient> _ingredientService;
    
    public IngredientController(IService<Ingredient> ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet("ingredient")]
    public override Task<IActionResult> Get([FromQuery] int id)
        => Task.FromResult<IActionResult>(Ok(_ingredientService.Get(id)));

        [HttpPost("ingredient")]
    public override Task<IActionResult> Update([FromBody] Ingredient ingredient)
        => Task.FromResult<IActionResult>(Ok(_ingredientService.Update(ingredient)));

    [HttpDelete("ingredient")]
    public override Task<IActionResult> Delete([FromQuery] int id) 
        => Task.FromResult<IActionResult>(Ok(_ingredientService.Delete(id)));

    [HttpGet("ingredients")]
    public override Task<IActionResult> GetAll() 
        => Task.FromResult<IActionResult>(Ok(_ingredientService.GetAll()));
}