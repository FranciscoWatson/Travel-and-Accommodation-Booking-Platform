using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Rooms;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Application.Queries.Rooms;
using TABP.Application.Validators.RoomValidators;

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
    
    [HttpGet("{roomId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<RoomForAdminResponseDto>> GetRoom(Guid roomId, CancellationToken cancellationToken = default)
    {
        var query = new GetRoomByIdQuery() { RoomId = roomId };
        
        var result = await _mediator.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<RoomForAdminResponseDto>>> GetRoomsForAdmin(CancellationToken cancellationToken = default)
    {
        var query = new GetAllRoomsForAdminQuery();
        
        var rooms = await _mediator.Send(query, cancellationToken);
        
        return Ok(rooms);
    }
    
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteRoom(Guid roomId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteRoomCommand() { RoomId = roomId };
        
        var result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : NotFound(result.ErrorMessage);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<RoomForAdminResponseDto>> CreateRoom(
        [FromBody] RoomForCreationRequestDto roomForCreationRequestDto,
        CancellationToken cancellationToken = default)
    {
        var validator = new RoomForCreationRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(roomForCreationRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = _mapper.Map<CreateRoomCommand>(roomForCreationRequestDto);
        
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.IsSuccess ? 
            CreatedAtAction(nameof(GetRoom), new { roomId = result.Data.RoomId }, result.Data) 
            : BadRequest(result.ErrorMessage);
    }
    
    [HttpPut("{roomId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateRoom(Guid roomId, RoomForUpdateRequestDto roomForUpdateRequestDto, CancellationToken cancellationToken = default)
    {
        var validator = new RoomForUpdateRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(roomForUpdateRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new UpdateRoomCommand { RoomId = roomId };
        _mapper.Map(roomForUpdateRequestDto, command);
        var result = await _mediator.Send(command, cancellationToken);
        return result.IsSuccess ? NoContent() : BadRequest(result.ErrorMessage);
    }
}