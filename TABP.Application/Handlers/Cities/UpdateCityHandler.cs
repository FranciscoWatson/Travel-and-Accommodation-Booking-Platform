using AutoMapper;
using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);
        if (city == null)
        {
            throw new ApplicationException($"City with id {request.CityId} not found.");
        }
        
        _mapper.Map(request, city);
        
        await _cityRepository.UpdateAsync(city);
    }
}