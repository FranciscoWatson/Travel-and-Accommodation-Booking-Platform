using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using TABP.Application.DTOs.Authentication;
using TABP.Domain.Entities;
using TABP.Domain.Models;
using TABP.Domain.Interfaces.Authentication;
using TABP.Domain.Interfaces.Repositories;
using IAuthenticationService = TABP.Domain.Interfaces.Authentication.IAuthenticationService;

namespace TABP.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<TokenInfo> LoginAsync(string username, string password)
    {
        var user = await ValidateUserCredentials(username, password);

        if (user == null)
        {
            throw new AuthenticationException("Username or password is incorrect.");
        }
        
        var tokenInfo = _jwtTokenGenerator.GenerateToken(user);
        
        return tokenInfo;
    }
    
    private async Task<User?> ValidateUserCredentials(string username, string password)
    {
        var user = await _userRepository.AuthenticateAsync(username, password); //add HashPassword method for password here, removed it for testing purposes
        return user;
    }
    
    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLowerInvariant();
    }
}