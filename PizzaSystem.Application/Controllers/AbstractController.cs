using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

public abstract class AbstractController<T> : ControllerBase where T : class
{
    public abstract IActionResult Get([FromQuery] Guid id);
    public abstract IActionResult Update(T entity);
    public abstract IActionResult Delete([FromQuery] Guid id);
    public abstract IActionResult GetAll();
}