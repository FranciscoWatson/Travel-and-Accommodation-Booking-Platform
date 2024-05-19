using AutoMapper;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Mappings;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelFullDetailsDto>()
            .ForMember(dto => dto.CityName, opt => opt.MapFrom(h => h.City.Name))
            .ForMember(dto => dto.OwnerName, opt => opt.MapFrom(h=> h.Owner.FirstName + " " + h.Owner.LastName));
    }
}