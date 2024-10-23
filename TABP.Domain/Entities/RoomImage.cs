namespace TABP.Domain.Entities;

public class RoomImage
{
    public Guid RoomImageId { get; set; }
    public Guid RoomTypeId { get; set; }
    public string Url { get; set; }
    public RoomType RoomType { get; set; }
}