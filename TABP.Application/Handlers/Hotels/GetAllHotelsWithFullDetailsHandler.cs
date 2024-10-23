using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class GetAllHotelsWithFullDetailsHandler : IRequestHandler<GetAllHotelsWithFullDetailsQuery, List<HotelFullDetailsDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetAllHotelsWithFullDetailsHandler(IHotelRepository hotelRepository, IMapper mapper)
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