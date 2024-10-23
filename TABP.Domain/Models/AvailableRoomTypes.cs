namespace TABP.Domain.Models;

public class AvailableRoomTypes
{
    public Guid RoomTypeId { get; set; }
    public string Name { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public string Description { get; set; }
    public List<string> RoomImagesUrls { get; set; }
}