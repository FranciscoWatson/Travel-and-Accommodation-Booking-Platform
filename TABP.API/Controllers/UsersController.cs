using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Application.Queries.Users;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet("recently-visited-hotels")]
    public async Task<ActionResult<IEnumerable<RecentlyVisitedHotelResponseDto>>> GetRecentlyVisitedHotels(
        [FromQuery] RecentlyVisitedHotelRequestDto recentlyVisitedHotelRequestDto,
        CancellationToken cancellationToken = default)
    {
        var query = _mapper.Map<GetRecentlyVisitedHotelsQuery>(recentlyVisitedHotelRequestDto);
        
        var hotels = await _mediator.Send(query, cancellationToken);
        
        return Ok(hotels);
    }
}