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

    /// <summary>
    /// Retrieves detailed information for a specific room by ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to retrieve.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns the detailed information of the room if found.</response>
    /// <response code="404">If no room is found with the provided ID.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the room.</response>
    [ProducesResponseType(typeof(RoomForAdminResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("{roomId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<RoomForAdminResponseDto>> GetRoom(Guid roomId, CancellationToken cancellationToken = default)
    {
        var query = new GetRoomByIdQuery() { RoomId = roomId };
        
        var result = await _mediator.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }
    
    /// <summary>
    /// Retrieves a list of all rooms available to administrators.
    /// </summary>
    /// <response code="200">Returns a list of all rooms accessible to admins.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the rooms.</response>
    [ProducesResponseType(typeof(IEnumerable<RoomForAdminResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<RoomForAdminResponseDto>>> GetRoomsForAdmin(CancellationToken cancellationToken = default)
    {
        var query = new GetAllRoomsForAdminQuery();
        
        var rooms = await _mediator.Send(query, cancellationToken);
        
        return Ok(rooms);
    }

    /// <summary>
    /// Deletes a specific room by ID.
    /// </summary>
    /// <param name="roomId">The ID of the room to delete.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="204">Indicates that the room was successfully deleted.</response>
    /// <response code="404">If the deletion was unsuccessful or the room does not exist.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to delete the room.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteRoom(Guid roomId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteRoomCommand() { RoomId = roomId };
        
        var result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess ? NoContent() : NotFound(result.ErrorMessage);
    }

    /// <summary>
    /// Creates a new room.
    /// </summary>
    /// <param name="roomForCreationRequestDto">The room creation data.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="201">Returns the newly created room.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to create a room.</response>
    [ProducesResponseType(typeof(RoomForAdminResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

    /// <summary>
    /// Updates details of an existing room.
    /// </summary>
    /// <param name="roomId">The ID of the room to update.</param>
    /// <param name="roomForUpdateRequestDto">The updated room data.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="204">Indicates that the room was successfully updated.</response>
    /// <response code="400">If the update is unsuccessful due to invalid data.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to update the room.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
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