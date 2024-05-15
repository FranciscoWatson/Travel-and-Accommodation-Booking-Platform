namespace TABP.Domain.Entities;

public abstract class AuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}