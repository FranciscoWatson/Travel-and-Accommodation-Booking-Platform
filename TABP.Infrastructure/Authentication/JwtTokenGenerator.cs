using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Authentication;
using TABP.Domain.Models;

namespace TABP.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtAuthenticationConfig _jwtAuthenticationConfig;

    public JwtTokenGenerator(JwtAuthenticationConfig jwtAuthenticationConfig)
    {
        _jwtAuthenticationConfig = jwtAuthenticationConfig;
    }
    public TokenInfo GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_jwtAuthenticationConfig.SecretKey));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForTokens = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, user.UserRole.Name)
        };

        var expiration = DateTime.UtcNow.AddMinutes(_jwtAuthenticationConfig.TokenExpiryInMinutes);
        
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtAuthenticationConfig.Issuer,
            audience: _jwtAuthenticationConfig.Audience,
            claims: claimsForTokens,
            notBefore: DateTime.UtcNow,
            expires: expiration,
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return new TokenInfo
        {
            Token = token,
            TokenType = "Bearer",
            ExpiresAt = expiration,
            User = user
        };
    }
}