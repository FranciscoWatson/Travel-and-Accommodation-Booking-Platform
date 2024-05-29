using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class DeleteCityHandler : IRequestHandler<DeleteCityCommand>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        await _cityRepository.DeleteAsync(request.CityId);
    }
}