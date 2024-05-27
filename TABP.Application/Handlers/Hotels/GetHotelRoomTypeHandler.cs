using AutoMapper;
using MediatR;
using TABP.Application.DTOs.RoomTypeDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;

namespace TABP.Application.Handlers.Hotels;

public class GetHotelRoomTypeHandler : IRequestHandler<GetHotelRoomTypesQuery, List<RoomTypeWithDiscountDto>>
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public GetHotelRoomTypeHandler(IRoomTypeRepository roomTypeRepository, IMapper mapper)
    {
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<RoomTypeWithDiscountDto>> Handle(GetHotelRoomTypesQuery request, CancellationToken cancellationToken)
    {
        var roomTypes = await _roomTypeRepository.GetAvailableRoomTypesAsync(request.HotelId, request.CheckIn, request.CheckOut);
        return _mapper.Map<List<RoomTypeWithDiscountDto>>(roomTypes);
    }
}