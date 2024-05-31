using TABP.Application.DTOs.UsersDto;

namespace TABP.Application.DTOs.Authentication;

public class LoginResponse
{
    public string Token { get; set; }
    public string TokenType { get; set; }
    public DateTime ExpiresAt { get; set; }
    public UserLoginDto UserLoginInfo { get; set; }
}