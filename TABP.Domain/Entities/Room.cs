namespace TABP.Domain.Entities;

public class Room : AuditableEntity
{
    public Guid RoomId { get; set; }
    public Guid RoomTypeId { get; set; }
    public Guid HotelId { get; set; }
    public decimal Price { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    
    public Hotel Hotel { get; set; }
    public RoomType RoomType { get; set; }
    public List<RoomImage> RoomImages { get; set; }
    public List<RoomDiscount> RoomDiscounts { get; set; }
    public List<Booking> Bookings { get; set; }
}