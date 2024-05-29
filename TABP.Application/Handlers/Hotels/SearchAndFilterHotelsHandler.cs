using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class SearchAndFilterHotelsHandler : IRequestHandler<SearchAndFilterHotelsQuery, List<HotelSearchResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public SearchAndFilterHotelsHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelSearchResponseDto>> Handle(SearchAndFilterHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await _hotelRepository.SearchAndFilterHotelsAsync(request);
        return _mapper.Map<List<HotelSearchResponseDto>>(hotels);
    }
}