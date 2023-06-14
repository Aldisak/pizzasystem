using Microsoft.AspNetCore.Mvc;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Application.Controllers;

public abstract class AbstractApiController<T> : ControllerBase where T : class
{
    public abstract Task<T?> Get(int id);
    public abstract Task<CreatedAtActionResult> Add(int id, T entity);
    public abstract Task<T> Update(int id, T entity);
    public abstract Task<T> Delete(int id);
    public abstract Task<IEnumerable<T>> GetAll();
}