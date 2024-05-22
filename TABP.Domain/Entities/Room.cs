namespace TABP.Domain.Entities;

public class Room : AuditableEntity
{
    public Guid RoomId { get; set; }
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
    public RoomType RoomType { get; set; }
    public List<BookingRoom> BookingRooms { get; set; }
}