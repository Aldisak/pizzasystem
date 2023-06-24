using MediatR;
using PizzaSystem.Core.Interfaces;
using PizzaSystem.Core.Models;

namespace PizzaSystem.Core.Commands;
public sealed record DeleteAlergenCommand(int Id) : IRequest<Alergen>;
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