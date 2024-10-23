using AutoMapper;
using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityForAdminDto>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCitiesHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CityForAdminDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CityForAdminDto>>(cities);
    }
}