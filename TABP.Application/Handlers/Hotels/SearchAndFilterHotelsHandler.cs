using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;

namespace TABP.Application.Handlers.Hotels;

public class SearchAndFilterHotelsHandler : IRequestHandler<SearchHotelQuery, List<HotelSearchResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public SearchAndFilterHotelsHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelSearchResponseDto>> Handle(SearchHotelQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.SearchAndFilterHotelsAsync(request);
        return _mapper.Map<List<HotelSearchResponseDto>>(hotels);
    }
}