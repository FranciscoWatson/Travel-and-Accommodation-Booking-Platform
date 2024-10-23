using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, Result<object>>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<Result<object>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var cityExists = await _cityRepository.ExistsAsync(request.CityId);
        if (!cityExists)
        {
            return Result<object>.Fail("City not found.");
        }

        await _cityRepository.DeleteAsync(request.CityId);
        return Result<object>.Success();
    }
}