namespace TABP.Application.DTOs.UsersDto;

public class UserLoginDto
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}