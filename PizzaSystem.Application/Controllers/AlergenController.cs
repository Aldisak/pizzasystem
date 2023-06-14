using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("alergens")]
public sealed class AlergenController : AbstractApiController<Alergen>
{
    private readonly IService<Alergen> _alergenService;

    public AlergenController(IService<Alergen> alergenService)
    {
        _alergenService = alergenService;
    }

    [HttpGet("{id:int}")]
    public override Task<Alergen?> Get([FromRoute] int id) => _alergenService.Get(id);

    [HttpPost("{id:int}")]
    public override Task<CreatedAtActionResult> Add([FromRoute] int id, [FromBody] Alergen alergen) 
        => _alergenService
                .Add(alergen)
                .ContinueWith(newItem 
                        => CreatedAtAction(nameof(Get), new {id = newItem.Result.Id}, newItem.Result));


    [HttpPut("{id:int}")]
    public override Task<Alergen> Update([FromRoute] int id, [FromBody] Alergen alergen) => _alergenService.Update(alergen);

    [HttpDelete("{id:int}")]
    public override Task<Alergen> Delete([FromRoute] int id) => _alergenService.Delete(id);

    [HttpGet]
    public override Task<IEnumerable<Alergen>> GetAll() =>  _alergenService.GetAll();
}