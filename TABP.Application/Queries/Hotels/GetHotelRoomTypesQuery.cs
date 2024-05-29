using MediatR;
using TABP.Application.DTOs.RoomTypeDTOs;

namespace TABP.Application.Queries.Hotels;

public class GetHotelRoomTypesQuery : IRequest<List<RoomTypeWithDiscountResponseDto>>
{
    public Guid HotelId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
}