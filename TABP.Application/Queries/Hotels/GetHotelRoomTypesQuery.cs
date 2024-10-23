using MediatR;
using TABP.Application.DTOs.RoomTypeDTOs;
using TABP.Application.Responses;

namespace TABP.Application.Queries.Hotels;

public class GetHotelRoomTypesQuery : IRequest<Result<List<RoomTypeWithDiscountResponseDto>>>
{
    public Guid HotelId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}