using MediatR;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Cities;

public class GetCityByIdQuery : IRequest<Result<CityDto>>
{
    public Guid CityId { get; set; }
}