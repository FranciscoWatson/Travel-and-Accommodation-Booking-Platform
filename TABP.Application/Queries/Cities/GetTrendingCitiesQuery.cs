using MediatR;
using TABP.Application.DTOs.CityDTOs;

namespace TABP.Application.Queries.Cities;

public class GetTrendingCitiesQuery : IRequest<List<TrendingCityDto>>
{
    public int Count { get; set; }
    
    public GetTrendingCitiesQuery(int count)
    {
        Count = count;
    }
}