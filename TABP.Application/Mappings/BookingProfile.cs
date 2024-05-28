using AutoMapper;
using TABP.Application.DTOs.BookingDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Mappings;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
            .ForMember(dto => dto.BookingDateUtc, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dto => dto.PaymentMethod, opt => opt.MapFrom(src => src.Payment != null ? src.Payment.PaymentMethod.ToString() : "Unknown"))
            .ForMember(dto => dto.PaymentStatus, opt => opt.MapFrom(src => src.Payment != null ? src.Payment.PaymentStatus.ToString() : "Unknown"))
            .ForMember(dto => dto.Rooms, opt => opt.MapFrom(src => src.BookingRooms.Select(br => br.Room)));
    }
}