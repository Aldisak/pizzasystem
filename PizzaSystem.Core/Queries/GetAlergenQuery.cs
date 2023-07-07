using FluentValidation;
using MediatR;
using PizzaSystem.Core.Entities;
using PizzaSystem.Core.Exceptions;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Queries;

public sealed record GetAlergenQuery(int Id) : IRequest<Alergen>;
public sealed class GetAlergenValidator : AbstractValidator<GetAlergenQuery>
{
    public GetAlergenValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
public class GetAlergenQueryHandler : IRequestHandler<GetAlergenQuery, Alergen>
{
    private readonly IRepository<Alergen> _repository;
    
    public GetAlergenQueryHandler(IRepository<Alergen> repository)
    {
        _repository = repository;
    }
    
    public async Task<Alergen> Handle(GetAlergenQuery request, CancellationToken cancellationToken)
    {
        var alergen = await _repository.Get(request.Id, cancellationToken);
        if (alergen is null) throw new EntityDoesNotExistException($"Alergen with id {request.Id} does not exists.");
        return alergen;
    }
}