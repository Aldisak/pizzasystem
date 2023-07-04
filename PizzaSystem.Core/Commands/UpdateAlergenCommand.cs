using Mapster;
using MediatR;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Commands;
public sealed record UpdateAlergenCommand(int Id, int Order, string Title, string Description) : IRequest<Alergen>;
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