using MediatR;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Queries.Cities;

public class GetCityByIdQuery : IRequest<CityDto>
{
    public Guid CityId { get; set; }
}