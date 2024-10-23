namespace TABP.Domain.Entities;

public class RoomType
{
    public Guid RoomTypeId { get; set; }
    public Guid HotelId { get; set; }
    public string Name { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public List<RoomImage> RoomImages { get; set; }
    public List<Discount> Discounts { get; set; }
    public Hotel Hotel { get; set; }
    public List<Room> Rooms { get; set; }
}