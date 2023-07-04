using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Commands;
using PizzaSystem.Core.Exceptions;
using PizzaSystem.Core.Models;
using PizzaSystem.Core.Queries;

namespace PizzaSystem.Application.Controllers;

[ApiController]
[Route("alergens")]
public sealed class AlergenController : AbstractApiController<Alergen>
{
    public AlergenController(IMediator mediator) : base(mediator) { }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] GetAlergenQuery request, CancellationToken cancellationToken = default) {
        try
        {
             var query = await Mediator.Send(request, cancellationToken);
             return Ok(query);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }

    [HttpPost]
    public Task<CreatedAtActionResult> Add([FromBody] CreateAlergenCommand request)
        => Mediator.Send(request)
                   .ContinueWith(x => CreatedAtAction(nameof(Get), new {id = x.Id}, null));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAlergenCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var command = request with { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteAlergenCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var result  = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        catch (EntityDoesNotExistException exception) { return NotFound(exception.Message); }
    }
    
    [HttpGet]
    public Task<OkObjectResult> GetAll(CancellationToken cancellationToken = default)
    => Mediator.Send(new GetAlergensQuery(), cancellationToken).ContinueWith(x => Ok(x.Result), cancellationToken);
}