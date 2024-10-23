using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Hotels;

public class GetHotelByIdQuery : IRequest<Result<HotelForAdminResponseDto>>
{
    public Guid HotelId { get; init; }
}