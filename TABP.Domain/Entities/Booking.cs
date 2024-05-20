namespace TABP.Domain.Entities;

public class Booking : AuditableEntity
{
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public decimal PriceAtBooking { get; set; }
    
    public Payment? Payment { get; set; }
    public User User { get; set; } 
    public List<BookingRoom> BookingRooms { get; set; }
}