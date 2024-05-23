using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Domain.Entities;

namespace TABP.Application.Queries.Hotels;

public class GetHotelsFeaturedDealsQuery : IRequest<List<HotelFeaturedDealsResponseDto>>
{
    public int Count { get; set; }
}