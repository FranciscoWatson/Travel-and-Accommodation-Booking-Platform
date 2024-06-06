using MediatR;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Bookings;

public class GetBookingByIdQuery : IRequest<Result<BookingDto>>
{
    public Guid BookingId { get; init; }
}