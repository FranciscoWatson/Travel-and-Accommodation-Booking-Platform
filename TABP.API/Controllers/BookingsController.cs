using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Bookings;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Queries.Bookings;

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
    public async Task<ActionResult<BookingDto>> GetBooking(
        Guid BookingId, CancellationToken cancellationToken)
    {
        var query = new GetBookingByIdQuery { BookingId = BookingId };

        var booking = await _mediator.Send(query, cancellationToken);

        return Ok(booking);
    }
}