using AutoMapper;
using MediatR;
using TABP.Application.Commands.Authentication;
using TABP.Application.DTOs.Authentication;
using TABP.Application.DTOs.UsersDto;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Authentication;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Users;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public LoginHandler(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var tokenInfo = await _authenticationService.LoginAsync(request.Username, request.Password);
        return _mapper.Map<LoginResponse>(tokenInfo);
    }
}