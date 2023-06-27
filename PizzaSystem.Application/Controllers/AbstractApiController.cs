using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PizzaSystem.Application.Controllers;

public abstract class AbstractApiController<T> : ControllerBase where T : class
{
    protected readonly IMediator Mediator;
    protected AbstractApiController(IMediator mediator) => Mediator = mediator;
}