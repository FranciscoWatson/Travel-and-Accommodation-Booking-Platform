using TABP.Domain.Entities;

namespace TABP.Domain.Models;

public class TokenInfo
{
    public string Token { get; set; }
    public string TokenType { get; set; }
    public DateTime ExpiresAt { get; set; }
    public User User { get; set; }
}