using AutoMapper;
using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, HotelForCreationResponseDto>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public CreateHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
    }

    public async Task<HotelForCreationResponseDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = _mapper.Map<Hotel>(request);
        var createdCity = await _hotelRepository.CreateAsync(hotel);
        return _mapper.Map<HotelForCreationResponseDto>(createdCity);
    }
}