namespace TABP.Domain.Entities;

public class RoomDiscount : AuditableEntity
{
    public Guid RoomDiscountId { get; set; }
    public Guid RoomTypeId { get; set; }
    public float Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RoomType RoomType { get; set; }
}