using AutoMapper;
using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, CityDto?>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityByIdHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityDto?> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);
        return city == null ? null : _mapper.Map<CityDto>(city);
    }
}