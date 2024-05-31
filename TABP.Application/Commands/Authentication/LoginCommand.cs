using MediatR;
using TABP.Application.DTOs.Authentication;

namespace TABP.Application.Commands.Authentication;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}