using AutoMapper;
using MediatR;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Interfaces.Repositories;
using TABP.Application.Queries.Hotels;

namespace TABP.Application.Handlers.Hotels;

public class GetHotelsFeaturedDealsHandler : IRequestHandler<GetHotelsFeaturedDealsQuery, List<HotelFeaturedDealsResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public GetHotelsFeaturedDealsHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<List<HotelFeaturedDealsResponseDto>> Handle(GetHotelsFeaturedDealsQuery request, CancellationToken cancellationToken)
    {
        var featuredDeals = await _hotelRepository.GetFeaturedDealsAsync(request.Count);
        
        return _mapper.Map<List<HotelFeaturedDealsResponseDto>>(featuredDeals);
    }
    
}