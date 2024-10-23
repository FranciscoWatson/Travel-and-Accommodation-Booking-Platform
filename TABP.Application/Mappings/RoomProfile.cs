using AutoMapper;
using TABP.Application.Commands.Rooms;
using TABP.Application.DTOs.RoomDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Mappings;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        CreateMap<Room, RoomDto>()
            .ForMember(dto => dto.RoomTypeName, opt => opt.MapFrom(src => src.RoomType.Name));
        
        CreateMap<Room, RoomForAdminResponseDto>()
            .ForMember(dto => dto.Available, opt => opt.MapFrom(src => !src.BookingRooms.Any(br => br.Booking.CheckIn <= DateTime.Now && br.Booking.CheckOut >= DateTime.Now)))
            .ForMember(dto => dto.AdultsCapacity, opt => opt.MapFrom(src => src.RoomType.AdultsCapacity))
            .ForMember(dto => dto.ChildrenCapacity, opt => opt.MapFrom(src => src.RoomType.ChildrenCapacity));
        
        CreateMap<RoomForCreationRequestDto, CreateRoomCommand>();
        CreateMap<CreateRoomCommand, Room>();
        CreateMap<Room, RoomForCreationResponseDto>();
        
        CreateMap<RoomForUpdateRequestDto, UpdateRoomCommand>();
        CreateMap<UpdateRoomCommand, Room>();
    }
}
