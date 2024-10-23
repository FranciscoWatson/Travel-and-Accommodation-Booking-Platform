using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Domain.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    TokenInfo GenerateToken(User user);
}