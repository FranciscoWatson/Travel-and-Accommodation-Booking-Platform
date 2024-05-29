using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Cities;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;


[ApiController]
[Route("/api/cities")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CitiesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("{cityId}")]
    public async Task<ActionResult<CityForAdminDto>> GetCity(Guid cityId, CancellationToken cancellationToken = default)
    {
        var query = new GetCityByIdQuery { CityId = cityId };
        
        var city = await _mediator.Send(query, cancellationToken);
        
        return Ok(city);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityForAdminDto>>> GetCities(CancellationToken cancellationToken = default)
    {
        var query = new GetCitiesQuery();
        
        var cities = await _mediator.Send(query, cancellationToken);
        
        return Ok(cities);
    }
    
    
    [HttpGet("trending")]
    public async Task<ActionResult<IEnumerable<TrendingCityDto>>> GetTrendingCities(int count = 5,
        CancellationToken cancellationToken = default)
    {
        var query = new GetTrendingCitiesQuery(count);
        
        var cities = await _mediator.Send(query, cancellationToken);
        
        return Ok(cities);
    }
    
    [HttpDelete("{cityId}")]
    public async Task<ActionResult> DeleteCity(Guid cityId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteCityCommand { CityId = cityId };
        
        await _mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}