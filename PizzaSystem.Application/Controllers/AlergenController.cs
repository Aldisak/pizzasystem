using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
public sealed class AlergenController : AbstractController<Alergen>
{
    private readonly IService<Alergen> _alergenService;
    
    public AlergenController(IService<Alergen> alergenService)
    {
        _alergenService = alergenService;
    }

    [HttpGet("alergen")]
    public override async Task<IActionResult> Get([FromQuery] Guid id)
        => Ok(await _alergenService.Get((Id<Alergen>) id));

        [HttpPost("alergen")]
    public override async Task<IActionResult> Update([FromBody] Alergen alergen)
        => Ok(await _alergenService.Update(alergen));

    [HttpDelete("alergen")]
    public override async Task<IActionResult> Delete([FromQuery] Guid id) 
        => Ok(await _alergenService.Delete((Id<Alergen>) id));

    [HttpGet("alergens")]
    public override async Task<IActionResult> GetAll() 
        => Ok(await _alergenService.GetAll());
}