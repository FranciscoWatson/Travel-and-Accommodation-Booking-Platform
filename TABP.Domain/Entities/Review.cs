namespace TABP.Domain.Entities;

public class Review : AuditableEntity
{
    public Guid ReviewId { get; set; }
    public Guid HotelId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
}