using TABP.Domain.Enums;

namespace TABP.Application.DTOs.BookingDTOs;

public class CreateBookingRequestDto
{
    public IEnumerable<Guid> RoomTypeId { get; init; }
    public DateOnly CheckIn { get; init; }
    public DateOnly Checkout { get; init; }
    public string? SpecialRequest { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
}