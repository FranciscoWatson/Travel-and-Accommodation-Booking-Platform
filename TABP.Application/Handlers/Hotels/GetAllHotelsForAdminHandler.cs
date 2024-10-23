using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class GetAllHotelsForAdminHandler : IRequestHandler<GetAllHotelsForAdminQuery, IEnumerable<HotelForAdminResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetAllHotelsForAdminHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HotelForAdminResponseDto>> Handle(GetAllHotelsForAdminQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.GetAllForAdminAsync();
        return _mapper.Map<IEnumerable<HotelForAdminResponseDto>>(hotels);
    }
}