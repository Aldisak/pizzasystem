using FluentValidation;
using MediatR;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Queries;
public sealed record GetAlergensQuery : IRequest<IEnumerable<Alergen>>;
public sealed class GetAlergensValidator : AbstractValidator<GetAlergensQuery>
{
    public GetAlergensValidator() { }
}

public class GetAlergensQueryHandler : IRequestHandler<GetAlergensQuery, IEnumerable<Alergen>>
{
    private readonly IRepository<Alergen> _repository;
    
    public GetAlergensQueryHandler(IRepository<Alergen> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Alergen>> Handle(GetAlergensQuery request, CancellationToken cancellationToken)
    {
        var alergens = await _repository.GetAll(cancellationToken);
        return alergens;
    }
}