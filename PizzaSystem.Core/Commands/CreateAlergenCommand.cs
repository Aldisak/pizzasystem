using Mapster;
using MediatR;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Commands;
public sealed record CreateAlergenCommand(int Order, string Title, string Description) : IRequest<int>;
public class CreateAlergenCommandHandler : IRequestHandler<CreateAlergenCommand, int>
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