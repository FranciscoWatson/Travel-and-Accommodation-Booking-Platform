using AutoMapper;
using MediatR;
using TABP.Application.DTOs.RoomTypeDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class GetHotelRoomTypeHandler : IRequestHandler<GetHotelRoomTypesQuery, Result<List<RoomTypeWithDiscountResponseDto>>>
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelRoomTypeHandler(IRoomTypeRepository roomTypeRepository, IMapper mapper, IHotelRepository hotelRepository)
    {
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<List<RoomTypeWithDiscountResponseDto>>> Handle(GetHotelRoomTypesQuery request, CancellationToken cancellationToken)
    {
        var hotelExists = await _hotelRepository.ExistsAsync(request.HotelId);
        if (!hotelExists)
        {
            return Result<List<RoomTypeWithDiscountResponseDto>>.Fail("Hotel not found.");
        }
        var roomTypes = await _roomTypeRepository.GetAvailableRoomTypesAsync(request.HotelId, request.CheckIn, request.CheckOut);
        var mappedRoomTypes = _mapper.Map<List<RoomTypeWithDiscountResponseDto>>(roomTypes);
        return Result<List<RoomTypeWithDiscountResponseDto>>.Success(mappedRoomTypes);
    }
}