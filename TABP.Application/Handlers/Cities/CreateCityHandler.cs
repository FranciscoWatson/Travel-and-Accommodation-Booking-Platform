using AutoMapper;
using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Responses;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class CreateCityHandler : IRequestHandler<CreateCityCommand, Result<CityForCreationResponseDto>>
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countriesRepository;
    private readonly IMapper _mapper;

    public CreateCityHandler(ICityRepository cityRepository, IMapper mapper, ICountryRepository countriesRepository)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _countriesRepository = countriesRepository;
    }

    public async Task<Result<CityForCreationResponseDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var countryExists = await _countriesRepository.ExistsAsync(request.CountryId);
        if (!countryExists)
        {
            return Result<CityForCreationResponseDto>.Fail("Country not found.");
        }
        var city = _mapper.Map<City>(request);
        var createdCity = await _cityRepository.CreateAsync(city);
        return Result<CityForCreationResponseDto>.Success(_mapper.Map<CityForCreationResponseDto>(createdCity));
    }
}