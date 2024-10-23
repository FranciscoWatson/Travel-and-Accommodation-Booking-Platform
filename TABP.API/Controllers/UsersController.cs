using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Application.Queries.Users;
using TABP.Application.Validators.HotelValidators;

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

    /// <summary>
    /// Retrieves a list of hotels recently visited by a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user whose hotel visit history is being requested.</param>
    /// <param name="recentlyVisitedHotelRequestDto">Parameters to specify the number of recently visited hotels to retrieve.</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Returns a list of recently visited hotels if available.</response>
    /// <response code="400">If the input parameters are invalid.</response>
    /// <response code="404">If no recent visits are found or the user does not exist.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the hotel visit history.</response>
    [ProducesResponseType(typeof(IEnumerable<RecentlyVisitedHotelResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("{userId}/recently-visited-hotels")]
    [Authorize(Roles = "Guest", Policy = "MatchUserId")]
    public async Task<ActionResult<IEnumerable<RecentlyVisitedHotelResponseDto>>> GetRecentlyVisitedHotels(
        Guid userId,
        [FromQuery] RecentlyVisitedHotelRequestDto recentlyVisitedHotelRequestDto,
        CancellationToken cancellationToken = default)
    {
        var validator = new RecentlyVisitedHotelRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(recentlyVisitedHotelRequestDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var query = new GetRecentlyVisitedHotelsQuery() { UserId = userId };
        _mapper.Map(recentlyVisitedHotelRequestDto, query);
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }
}