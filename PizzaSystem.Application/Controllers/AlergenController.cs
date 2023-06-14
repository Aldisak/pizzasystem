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
    public override Task<IActionResult> Get([FromQuery] int id)
        => Task.FromResult<IActionResult>(Ok(_alergenService.Get(id)));

        [HttpPost("alergen")]
    public override Task<IActionResult> Update([FromBody] Alergen alergen)
        => Task.FromResult<IActionResult>(Ok(_alergenService.Update(alergen)));

    [HttpDelete("alergen")]
    public override Task<IActionResult> Delete([FromQuery] int id) 
        => Task.FromResult<IActionResult>(Ok(_alergenService.Delete(id)));

    [HttpGet("alergens")]
    public override Task<IActionResult> GetAll() 
        => Task.FromResult<IActionResult>(Ok(_alergenService.GetAll()));
}