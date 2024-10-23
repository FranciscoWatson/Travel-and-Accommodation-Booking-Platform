namespace TABP.Domain.Entities;

public class UserRole
{
    public Guid UserRoleId { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
}