using TABP.Domain.Enums;

namespace TABP.Domain.Entities;

public class User : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid UserRoleId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public UserRole UserRole { get; set; }
    public List<Booking> Bookings { get; set; }
    public List<Review> Reviews { get; set; }
}