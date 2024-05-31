using TABP.Domain.Entities;

namespace TABP.Domain.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}