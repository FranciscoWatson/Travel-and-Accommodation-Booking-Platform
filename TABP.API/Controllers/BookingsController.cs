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
    
    [HttpGet("{BookingId}")]
    [Authorize(Roles = "Guest")]

    public async Task<ActionResult<BookingDto>> GetBooking(
        Guid BookingId, CancellationToken cancellationToken)
    {
        var query = new GetBookingByIdQuery { BookingId = BookingId };

        var booking = await _mediator.Send(query, cancellationToken);

        return Ok(booking);
    }
    
    [HttpPost]
    [Authorize(Roles = "Guest")]
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