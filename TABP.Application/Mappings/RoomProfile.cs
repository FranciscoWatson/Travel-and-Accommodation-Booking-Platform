using AutoMapper;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>()
            .ForMember(dto => dto.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name));
    }
}
