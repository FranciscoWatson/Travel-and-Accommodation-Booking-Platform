using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Bookings;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Queries.Bookings;
using TABP.Application.Validators.BookingValidators;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("/api/bookings")]

public class BookingsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BookingsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Retrieves a specific booking by its ID.
    /// </summary>
    /// <param name="bookingId">The unique identifier for the booking.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Returns the booking information.</returns>
    /// <response code="200">Returns the retrieved booking.</response>
    /// <response code="404">If no booking is found with the provided ID.</response>
    /// <response code="403">If the user is not authorized to view the booking.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [HttpGet("{bookingId}")]
    [Authorize(Roles = "Guest")]
    [ProducesResponseType(typeof(BookingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BookingDto>> GetBooking(
        Guid bookingId, CancellationToken cancellationToken)
    {
        var query = new GetBookingByIdQuery { BookingId = bookingId };

        var booking = await _mediator.Send(query, cancellationToken);
        
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(booking);
    }
    
    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <response code="201">Returns the newly created booking.</response>
    /// <response code="400">If the booking details are invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to create a booking.</response>
    [HttpPost]
    [Authorize(Roles = "Guest")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> CreateBooking([FromBody] CreateBookingRequestDto createBookingRequestDto, CancellationToken cancellationToken = default)
    {
        var validator = new CreateBookingRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(createBookingRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = _mapper.Map<CreateBookingCommand>(createBookingRequestDto);
        
        var booking = await _mediator.Send(command, cancellationToken);
        
        return CreatedAtAction(nameof(GetBooking), new { BookingId = booking.BookingId }, booking);
    }
}