using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Application.Responses;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdQuery, Result<HotelForAdminResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelByIdHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<Result<HotelForAdminResponseDto>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAdminAsync(request.HotelId);
        if (hotel == null)
        {
            return Result<HotelForAdminResponseDto>.Fail("Hotel not found.");
        }
        return Result<HotelForAdminResponseDto>.Success(_mapper.Map<HotelForAdminResponseDto>(hotel));
    }
}