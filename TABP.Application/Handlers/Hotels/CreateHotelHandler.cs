using AutoMapper;
using MediatR;
using TABP.Application.Commands.Hotels;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.Responses;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces.Repositories;

namespace TABP.Application.Handlers.Hotels;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, Result<HotelForCreationResponseDto>>
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public CreateHotelHandler(IHotelRepository hotelRepository, IMapper mapper, IOwnerRepository ownerRepository)
    {
        _hotelRepository = hotelRepository;
        _mapper = mapper;
        _ownerRepository = ownerRepository;
    }

    public async Task<Result<HotelForCreationResponseDto>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var existsAsync = await _ownerRepository.ExistsAsync(request.OwnerId);
        if (!existsAsync)
        {
            return Result<HotelForCreationResponseDto>.Fail("Owner not found.");
        }
        var hotel = _mapper.Map<Hotel>(request);
        var createdCity = await _hotelRepository.CreateAsync(hotel);
        var dto = _mapper.Map<HotelForCreationResponseDto>(createdCity);
        return Result<HotelForCreationResponseDto>.Success(dto);
    }
}