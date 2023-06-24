using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Application.Requests;
using PizzaSystem.Core.Commands;
using PizzaSystem.Core.Exceptions;
using PizzaSystem.Core.Models;
using PizzaSystem.Core.Services;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("alergens")]
public sealed class AlergenController : AbstractApiController<Alergen>
{
    public AlergenController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken = default) {
        try
        {
             var query = await Mediator.Send(new GetAlergenQuery(id), cancellationToken);
             return Ok(query);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }

    [HttpPost]
    public Task<CreatedAtActionResult> Add([FromBody] CreateAlergenRequest request)
        => Mediator.Send(request.Adapt<CreateAlergenCommand>())
                   .ContinueWith(x => CreatedAtAction(nameof(Get), new {id = x.Id}, null));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAlergenRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var command = request.Adapt<UpdateAlergenCommand>() with { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var command = new DeleteAlergenCommand(id);
            var result  = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var query = await Mediator.Send(new GetAlergensQuery(), cancellationToken);
        return Ok(query);
    }
}