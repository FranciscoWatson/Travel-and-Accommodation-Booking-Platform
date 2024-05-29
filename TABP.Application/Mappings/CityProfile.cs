using AutoMapper;
using TABP.Application.DTOs.CityDTOs;
using TABP.Domain.Entities;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<TrendingCity, TrendingCityDto>().ReverseMap();
        CreateMap<City, CityForAdminDto>()
            .ForMember(dto => dto.NumberOfHotels, opt => opt.MapFrom(c => c.Hotels.Count));
        
        CreateMap<City, CityDto>()
            .ForMember(dto => dto.CountryName, opt => opt.MapFrom(c => c.Country.Name));
    }
}