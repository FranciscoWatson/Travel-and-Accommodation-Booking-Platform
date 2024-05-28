using MediatR;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Domain.Enums;

namespace TABP.Application.Commands.Bookings;

public class CreateBookingCommand : IRequest<BookingDto>
{
    public Guid UserId { get; init; }
    public IEnumerable<Guid> RoomTypeIds { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public string? SpecialRequest { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
}