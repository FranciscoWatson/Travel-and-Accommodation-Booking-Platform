using AutoMapper;
using TABP.Application.DTOs.CityDTOs;
using TABP.Domain.Models;

namespace TABP.Application.Mappings;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<TrendingCity, TrendingCityDto>().ReverseMap();
    }
}