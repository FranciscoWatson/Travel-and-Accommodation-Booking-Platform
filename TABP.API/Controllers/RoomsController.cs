using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Queries.Rooms;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("/api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoomsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    // -----Admin Methods (add auth later)-----

    [HttpGet("{roomId}")]
    public async Task<ActionResult<RoomForAdminResponseDto>> GetRoom(Guid roomId, CancellationToken cancellationToken = default)
    {
        var query = new GetRoomByIdQuery() { RoomId = roomId };
        
        var room = await _mediator.Send(query, cancellationToken);
        
        return Ok(room);
    }
}