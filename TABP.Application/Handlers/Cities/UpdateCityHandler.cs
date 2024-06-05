using AutoMapper;
using MediatR;
using TABP.Application.Commands.Cities;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Result>
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper, ICountryRepository countryRepository)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
        _countryRepository = countryRepository;
    }

    public async Task<Result> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);
        if (city == null)
        {
            return Result.Fail("City not found.");
        }
        
        var country = await _countryRepository.GetByIdAsync(request.CountryId);
        if (country == null)
        {
            return Result.Fail("Country not found.");
        }
        
        _mapper.Map(request, city);
        
        await _cityRepository.UpdateAsync(city);
        return Result.Success();
    }
}