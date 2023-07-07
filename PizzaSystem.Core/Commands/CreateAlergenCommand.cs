using FluentValidation;
using Mapster;
using MediatR;
using PizzaSystem.Core.Entities;
using PizzaSystem.Core.Interfaces;

namespace PizzaSystem.Core.Commands;
public sealed record CreateAlergenCommand(int Order, string Title, string Description) : IRequest<int>;
public sealed class CreateAlergenValidator : AbstractValidator<CreateAlergenCommand>
{
    public CreateAlergenValidator() 
    {
        RuleFor(x => x.Order).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
public sealed record CreateAlergenCommandHandler : IRequestHandler<CreateAlergenCommand, int>
{
    private readonly IRepository<Alergen> _repository;

    public CreateAlergenCommandHandler(IRepository<Alergen> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateAlergenCommand request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<Alergen>();
        return await _repository.Add(command, cancellationToken);
    }
}