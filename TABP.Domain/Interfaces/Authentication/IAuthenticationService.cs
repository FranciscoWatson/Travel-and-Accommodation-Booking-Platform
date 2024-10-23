using TABP.Domain.Models;

namespace TABP.Domain.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<TokenInfo> LoginAsync(string username, string password);
}