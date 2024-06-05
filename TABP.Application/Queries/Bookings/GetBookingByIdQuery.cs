using MediatR;
using TABP.Application.DTOs.BookingDTOs;

namespace TABP.Application.Queries.Bookings;

public class GetBookingByIdQuery : IRequest<BookingDto?>
{
    public Guid BookingId { get; init; }
}