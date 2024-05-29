using AutoMapper;
using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Application.DTOs.CityDTOs;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class CreateCityHandler : IRequestHandler<CreateCityCommand, CityDto>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var city = _mapper.Map<City>(request);
        var createdCity = await _cityRepository.CreateAsync(city);
        return _mapper.Map<CityDto>(createdCity);
    }
}