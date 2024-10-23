using AutoMapper;
using TABP.Application.Commands.Authentication;
using TABP.Application.DTOs.Authentication;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<LoginRequestBody, LoginCommand>();
       
        CreateMap<TokenInfo, LoginResponse>()
            .ForMember(dest => dest.UserLoginInfo, opt => opt.MapFrom(src => src.User));
    }
}