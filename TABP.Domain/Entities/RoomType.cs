namespace TABP.Domain.Entities;

public class RoomType
{
    public Guid RoomTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float RoomPriceMultiplier { get; set; }
}