using AutoMapper;
using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Cities;

public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, Result<CityDto>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public GetCityByIdHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<Result<CityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);
        
        return city == null
            ? Result<CityDto>.Fail("City not found.")
            : Result<CityDto>.Success(_mapper.Map<CityDto>(city));
    }
}