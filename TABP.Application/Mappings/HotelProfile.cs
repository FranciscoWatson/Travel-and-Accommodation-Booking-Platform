using AutoMapper;
using TABP.Application.Commands.Hotels;
using TABP.Application.DTOs.AmenityDTOs;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.DTOs.HotelImageDTOs;
using TABP.Application.DTOs.ReviewDTOs;
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
            .ForMember(dto => dto.OwnerName, opt => opt.MapFrom(h => h.Owner.FirstName + " " + h.Owner.LastName))
            .ForMember(dto => dto.Amenities, opt => opt.MapFrom(src => src.HotelAmenities.Select(ha => new AmenityDto
            {
                AmenityId = ha.Amenity.AmenityId,
                Name = ha.Amenity.Name,
                Description = ha.Amenity.Description
            })))
            .ForMember(dto => dto.Reviews, opt => opt.MapFrom(h => h.Reviews.Select(r => new ReviewDto
            {
                ReviewId = r.ReviewId,
                Rating = r.Rating,
                Content = r.Content,
                UserId = r.UserId
            })))
            .ForMember(dto => dto.HotelImages, opt => opt.MapFrom(h => h.HotelImages.Select(i => new HotelImageDto
            {
                HotelImageId = i.HotelImageId,
                Url = i.Url
            })));
        
        CreateMap<HotelSearch, HotelSearchResponseDto>()
            .ForMember(dto => dto.HotelImages, opt => opt.MapFrom(h => h.HotelImages.Select(i => new HotelImageDto
            {
                HotelImageId = i.HotelImageId,
                Url = i.Url
            })))
            .ForMember(dto => dto.Amenities, opt => opt.MapFrom(h => h.Amenities.Select(a => new AmenityDto
            {
                AmenityId = a.AmenityId,
                Name = a.Name,
                Description = a.Description
            })));
        
        CreateMap<HotelSearchRequestDto, SearchAndFilterHotelsQuery>().ReverseMap();
        
        CreateMap<HotelFeaturedDealsRequestDto, GetHotelsFeaturedDealsQuery>().ReverseMap();
        
        CreateMap<FeaturedDeal, HotelFeaturedDealsResponseDto>().ReverseMap();
        
        CreateMap<Hotel, HotelForAdminResponseDto>()
            .ForMember(dto => dto.OwnerName, opt => opt.MapFrom(h => h.Owner.FirstName + " " + h.Owner.LastName))
            .ForMember(dto => dto.NumberOfRooms, opt => opt.MapFrom(h => h.RoomTypes.Sum(rt => rt.Rooms.Count)));

        CreateMap<Hotel, HotelForCreationResponseDto>();
        CreateMap<CreateHotelCommand, Hotel>();
        CreateMap<HotelForCreationRequestDto, CreateHotelCommand>();
        CreateMap<UpdateHotelCommand, Hotel>();
        CreateMap<HotelForUpdateRequestDto, UpdateHotelCommand>();
    }
}