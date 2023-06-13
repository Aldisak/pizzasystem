using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

public abstract class AbstractController<T> : ControllerBase where T : class
{
    public abstract Task<IActionResult> Get(int id);
    public abstract Task<IActionResult> Update(T entity);
    public abstract Task<IActionResult> Delete(int id);
    public abstract Task<IActionResult> GetAll();
}