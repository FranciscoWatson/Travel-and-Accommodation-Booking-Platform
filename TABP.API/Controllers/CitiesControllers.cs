using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;


[ApiController]
[Route("/api/cities")]
public class CitiesControllers : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CitiesControllers(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("trending")]
    public async Task<ActionResult<IEnumerable<TrendingCityDto>>> GetTrendingCities(int count = 5,
        CancellationToken cancellationToken = default)
    {
        var query = new GetTrendingCitiesQuery(count);
        
        var cities = await _mediator.Send(query, cancellationToken);
        
        return Ok(cities);
    }
}