using TABP.Application.DTOs.RoomDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.DTOs.BookingDTOs;

public class BookingDto
{
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public decimal PriceAtBooking { get; set; }
    public string? SpecialRequest { get; set; }
    public DateTime BookingDateUtc { get; init; }
    public string PaymentMethod { get; init; }
    public string PaymentStatus { get; set; } 
    public List<RoomDto> Rooms { get; set; }
}
