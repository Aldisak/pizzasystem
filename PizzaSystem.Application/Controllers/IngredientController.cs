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
    public override async Task<IActionResult> Get([FromQuery] Guid id)
        => Ok(await _ingredientService.Get((Id<Ingredient>) id));

        [HttpPost("ingredient")]
    public override async Task<IActionResult> Update([FromBody] Ingredient ingredient)
        => Ok(await _ingredientService.Update(ingredient));

    [HttpDelete("ingredient")]
    public override async Task<IActionResult> Delete([FromQuery] Guid id) 
        => Ok(await _ingredientService.Delete((Id<Ingredient>) id));

    [HttpGet("ingredients")]
    public override async Task<IActionResult> GetAll() 
        => Ok(await _ingredientService.GetAll());
}