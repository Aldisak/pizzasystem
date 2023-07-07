using FluentValidation;
using MediatR;
using PizzaSystem.Core.Entities;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Commands;
public sealed record DeleteAlergenCommand(int Id) : IRequest<Alergen>;
public sealed class DeleteAlergenValidator : AbstractValidator<DeleteAlergenCommand>
{
    public DeleteAlergenValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
public class DeleteAlergenCommandHandler : IRequestHandler<DeleteAlergenCommand, Alergen>
{
    private readonly IRepository<Alergen> _repository;

    public DeleteAlergenCommandHandler(IRepository<Alergen> repository)
    {
        _repository = repository;
    }

    public async Task<Alergen> Handle(DeleteAlergenCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.Id, cancellationToken);
    }
}