using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdQuery, HotelForAdminResponseDto>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelByIdHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<HotelForAdminResponseDto> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAdminAsync(request.HotelId);
        return _mapper.Map<HotelForAdminResponseDto>(hotel);
    }
}