using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;

namespace TABP.Application.Handlers.Hotels;

public class GetAllHotelsWithFullDetailsQueryHandler : IRequestHandler<GetAllHotelsWithFullDetailsQuery, List<HotelFullDetailsDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetAllHotelsWithFullDetailsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelFullDetailsDto>> Handle(GetAllHotelsWithFullDetailsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.GetAllWithFullDetailsAsync();
        return _mapper.Map<List<HotelFullDetailsDto>>(hotels);
    }
}