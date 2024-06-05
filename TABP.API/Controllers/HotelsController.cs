using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Hotels;
using TABP.Application.DTOs.HotelDTOs;
using TABP.Application.DTOs.RoomTypeDTOs;
using TABP.Application.Queries.Hotels;
using TABP.Application.Validators.HotelValidators;
using TABP.Application.Validators.RoomTypeValidators;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("/api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HotelsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelFullDetailsDto>>> GetHotels(CancellationToken cancellationToken = default)
    {
        var hotels = await _mediator.Send(new GetAllHotelsWithFullDetailsQuery(), cancellationToken);
        
        return Ok(hotels);
    }

    
    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelSearchResponseDto>>> SearchHotels(
        [FromQuery] HotelSearchRequestDto hotelSearchRequest,
        CancellationToken cancellationToken = default)
    {
        var validator = new HotelSearchRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(hotelSearchRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var query = _mapper.Map<SearchAndFilterHotelsQuery>(hotelSearchRequest);
        
        var hotels = await _mediator.Send(query, cancellationToken);
        
        return Ok(hotels);
    }
    
    [HttpGet("featured-deals")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelSearchResponseDto>>> GetHotelsFeaturedDeals(
        [FromQuery] HotelFeaturedDealsRequestDto hotelsFeaturedDealsRequest,
        CancellationToken cancellationToken = default)
    {
        var validator = new HotelFeaturedDealsRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(hotelsFeaturedDealsRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var query = _mapper.Map<GetHotelsFeaturedDealsQuery>(hotelsFeaturedDealsRequest);
        
        var hotels = await _mediator.Send(query, cancellationToken);
        
        return Ok(hotels);
    }
    
    [HttpGet("{hotelId}/room-types")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RoomTypeWithDiscountResponseDto>>> GetHotelRoomTypes(
        [FromRoute] Guid hotelId,
        [FromQuery] RoomTypeWithDiscountRequestDto roomTypeWithDiscountRequestDto,
        CancellationToken cancellationToken = default)
    {
        var validator = new RoomTypeWithDiscountRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(roomTypeWithDiscountRequestDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var query = _mapper.Map<GetHotelRoomTypesQuery>(roomTypeWithDiscountRequestDto, opts => 
            opts.AfterMap((src, dest) => dest.HotelId = hotelId));

        var roomTypes = await _mediator.Send(query, cancellationToken);

        return Ok(roomTypes);
    }
    
    [HttpGet("{hotelId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<HotelForAdminResponseDto>> GetHotel(Guid hotelId, CancellationToken cancellationToken = default)
    {
        var query = new GetHotelByIdQuery { HotelId = hotelId };
        
        var hotel = await _mediator.Send(query, cancellationToken);
        
        return Ok(hotel);
    }
    
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<HotelForAdminResponseDto>>> GetHotelsForAdmins(CancellationToken cancellationToken = default)
    {
        var hotels = await _mediator.Send(new GetAllHotelsForAdminQuery(), cancellationToken);
        
        return Ok(hotels);
    }
    
    [HttpDelete("{hotelId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteHotel(Guid hotelId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteHotelCommand { HotelId = hotelId };
        
        await _mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<HotelForAdminResponseDto>> CreateHotel(
        [FromBody] HotelForCreationRequestDto hotelForCreationRequestDto,
        CancellationToken cancellationToken = default)
    {
        var validator = new HotelForCreationRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(hotelForCreationRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = _mapper.Map<CreateHotelCommand>(hotelForCreationRequestDto);
        
        var hotel = await _mediator.Send(command, cancellationToken);
        
        return CreatedAtAction(nameof(GetHotel), new { hotelId = hotel.HotelId }, hotel);
    }
    
    [HttpPut("{hotelId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateHotel(Guid hotelId, HotelForUpdateRequestDto hotelForUpdateRequestDto, CancellationToken cancellationToken = default)
    {
        var validator = new HotelForUpdateRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(hotelForUpdateRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new UpdateHotelCommand { HotelId = hotelId };
        _mapper.Map(hotelForUpdateRequestDto, command);
        await _mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}