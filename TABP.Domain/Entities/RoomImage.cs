namespace TABP.Domain.Entities;

public class RoomImage
{
    public Guid RoomImageId { get; set; }
    public string Url { get; set; }
    public List<Room> Rooms { get; set; }
}