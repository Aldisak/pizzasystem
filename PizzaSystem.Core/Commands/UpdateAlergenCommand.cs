using FluentValidation;
using Mapster;
using MediatR;
using PizzaSystem.Core.Entities;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Commands;
public sealed record UpdateAlergenCommand(int Id, int Order, string Title, string Description) : IRequest<Alergen>;
public sealed class UpdateAlergenValidator : AbstractValidator<UpdateAlergenCommand>
{
    public UpdateAlergenValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Order).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
public class UpdateAlergenCommandHandler : IRequestHandler<UpdateAlergenCommand, Alergen>
{
    private readonly IRepository<Alergen> _repository;

    public UpdateAlergenCommandHandler(IRepository<Alergen> repository)
    {
        _repository = repository;
    }

    public async Task<Alergen> Handle(UpdateAlergenCommand request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<Alergen>();
        return await _repository.Update(command, cancellationToken);
    }
}