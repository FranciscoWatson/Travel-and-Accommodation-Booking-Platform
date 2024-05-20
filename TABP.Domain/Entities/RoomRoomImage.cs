namespace TABP.Domain.Entities;

public class RoomRoomImage
{
    public Guid RoomId { get; set; }
    public Guid RoomImageId { get; set; }
    public Room Room { get; set; }
    public RoomImage RoomImage { get; set; }
}