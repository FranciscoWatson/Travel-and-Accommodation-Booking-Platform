using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("/api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HotelsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelSearchResponseDto>>> SearchHotels(
        [FromQuery] SearchAndFilterHotelsRequestDto searchAndFilterHotelsRequest,
        CancellationToken cancellationToken = default)
    {
        var query = _mapper.Map<SearchAndFilterHotelsQuery>(searchAndFilterHotelsRequest);
        
        var hotels = await _mediator.Send(query, cancellationToken);
        
        return Ok(hotels);
    }
}