namespace TABP.Domain.Entities;

public class BookingRoom
{
    public Guid BookingId { get; set; }
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    public Booking Booking { get; set; }
}