namespace TABP.Application.DTOs.RoomDTOs;

public class RoomForAdminResponseDto
{
    public Guid RoomId { get; set; }
    public Guid RoomTypeId { get; set; }
    public int RoomNumber { get; set; }
    public bool Available { get; set; }
    public int AdultsCapacity { get; set; }
    public int ChildrenCapacity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}