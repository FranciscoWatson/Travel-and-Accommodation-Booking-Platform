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