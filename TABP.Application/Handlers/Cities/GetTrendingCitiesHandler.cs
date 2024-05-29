using AutoMapper;
using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class GetTrendingCitiesHandler : IRequestHandler<GetTrendingCitiesQuery, List<TrendingCityDto>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetTrendingCitiesHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<List<TrendingCityDto>> Handle(GetTrendingCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetTrendingCities(request.Count);
        return _mapper.Map<List<TrendingCityDto>>(cities);
    }
}