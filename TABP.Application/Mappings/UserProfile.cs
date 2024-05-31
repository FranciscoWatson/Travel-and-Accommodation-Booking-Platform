using AutoMapper;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.DTOs.UsersDto;
using TABP.Application.Queries.Users;
using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RecentlyVisitedHotelRequestDto, GetRecentlyVisitedHotelsQuery>().ReverseMap();
        
        CreateMap<RecentlyVisitedHotel, RecentlyVisitedHotelResponseDto>().ReverseMap();
        
        CreateMap<User, UserLoginDto>();
    }
}