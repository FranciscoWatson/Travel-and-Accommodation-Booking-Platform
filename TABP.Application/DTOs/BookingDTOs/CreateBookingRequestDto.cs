using TABP.Domain.Enums;

namespace TABP.Application.DTOs.BookingDTOs;

public class CreateBookingRequestDto
{
    public Guid UserId { get; init; }
    public IEnumerable<Guid> RoomTypeIds { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime Checkout { get; init; }
    public string? SpecialRequest { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
}