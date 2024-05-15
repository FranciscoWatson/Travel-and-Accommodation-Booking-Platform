namespace TABP.Domain.Entities;

public class RoomDiscount
{
    public Guid RoomDiscountId { get; set; }
    public float Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Room> Rooms { get; set; }
}