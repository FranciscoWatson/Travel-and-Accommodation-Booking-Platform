using AutoMapper;
using TABP.Application.DTOs.AmenityDTOs;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.DTOs.HotelImageDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, HotelFullDetailsDto>()
            .ForMember(dto => dto.CityName, opt => opt.MapFrom(h => h.City.Name))
            .ForMember(dto => dto.OwnerName, opt => opt.MapFrom(h=> h.Owner.FirstName + " " + h.Owner.LastName));

        CreateMap<Hotel, HotelSearchResponseDto>()
            .ForMember(dto => dto.CityName, opt => opt.MapFrom(h => h.City.Name))
            .ForMember(dto => dto.HotelImages, opt => opt.MapFrom(h => h.HotelImages.Select(i => new HotelImageDto
            {
                HotelImageId = i.HotelImageId,
                Url = i.Url
            })))
            .ForMember(dto => dto.Amenities, opt => opt.MapFrom(h => h.HotelAmenities.Select(a => new AmenityDto
            {
                AmenityId = a.AmenityId,
                Name = a.Amenity.Name,
                Description = a.Amenity.Description
            })));
        
        CreateMap<SearchAndFilterHotelsRequestDto, SearchAndFilterHotelsQuery>().ReverseMap();
        
        CreateMap<HotelFeaturedDealsRequestDto, GetHotelsFeaturedDealsQuery>().ReverseMap();
        
        CreateMap<FeaturedDeal, HotelFeaturedDealsResponseDto>().ReverseMap();
    }
}