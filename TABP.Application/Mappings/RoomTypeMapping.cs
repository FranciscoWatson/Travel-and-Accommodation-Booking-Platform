using AutoMapper;
using TABP.Application.DTOs.RoomTypeDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class RoomTypeMapping : Profile
{
    public RoomTypeMapping()
    {
        CreateMap<AvailableRoomTypes, RoomTypeWithDiscountResponseDto>().ReverseMap();
        CreateMap<RoomTypeWithDiscountRequestDto, GetHotelRoomTypesQuery>().ReverseMap();
    }
}
