using MediatR;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Queries.Cities;

public class GetCitiesQuery : IRequest<IEnumerable<CityForAdminDto>>
{
    
}