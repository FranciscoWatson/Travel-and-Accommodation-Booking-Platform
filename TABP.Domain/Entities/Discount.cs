namespace TABP.Domain.Entities;

public class Discount : AuditableEntity
{
    public Guid DiscountId { get; set; }
    public Guid RoomTypeId { get; set; }
    public float Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RoomType RoomType { get; set; }
}