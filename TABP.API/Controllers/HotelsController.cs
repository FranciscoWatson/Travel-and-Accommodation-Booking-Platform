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
    
    /// <summary>
    /// Retrieves a list of all hotels with full details.
    /// </summary>
    /// <response code="200">Returns a list of hotels with full details.</response>
    /// <returns>A list of all Hotels with their full details.</returns>
    [ProducesResponseType(typeof(IEnumerable<HotelFullDetailsDto>), StatusCodes.Status200OK)]
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelFullDetailsDto>>> GetHotels(CancellationToken cancellationToken = default)
    {
        var hotels = await _mediator.Send(new GetAllHotelsWithFullDetailsQuery(), cancellationToken);
        
        return Ok(hotels);
    }

    /// <summary>
    /// Searches for hotels based on provided search criteria.
    /// </summary>
    /// <param name="hotelSearchRequest">Filtering criteria for hotels.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns matched hotels based on the search criteria.</response>
    /// <response code="400">If the search parameters are invalid.</response>
    [ProducesResponseType(typeof(IEnumerable<HotelSearchResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Retrieves a list of hotels with featured deals.
    /// </summary>
    /// <param name="hotelsFeaturedDealsRequest">The count of deals to retrieve.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns featured hotel deals.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    [ProducesResponseType(typeof(IEnumerable<HotelSearchResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    /// <summary>
    /// Retrieves the room types available in a specified hotel.
    /// </summary>
    /// <param name="hotelId">The ID of the hotel.</param>
    /// <param name="roomTypeWithDiscountRequestDto">Filtering criteria for room types.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns available room types for the specified hotel.</response>
    /// <response code="400">If the request parameters are invalid.</response>
    [ProducesResponseType(typeof(IEnumerable<RoomTypeWithDiscountResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        var result = await _mediator.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }
    
    /// <summary>
    /// Retrieves detailed information for a specific hotel by ID.
    /// </summary>
    /// <param name="hotelId">The ID of the hotel to retrieve.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns the detailed information of the hotel if found.</response>
    /// <response code="404">If no hotel is found with the provided ID.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the hotel.</response>
    [ProducesResponseType(typeof(HotelForAdminResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("{hotelId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<HotelForAdminResponseDto>> GetHotel(Guid hotelId, CancellationToken cancellationToken = default)
    {
        var query = new GetHotelByIdQuery { HotelId = hotelId };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }
    
    /// <summary>
    /// Retrieves a list of all hotels available to administrators.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns a list of all hotels accessible to admins.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the hotels.</response>
    [ProducesResponseType(typeof(IEnumerable<HotelForAdminResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<HotelForAdminResponseDto>>> GetHotelsForAdmins(CancellationToken cancellationToken = default)
    {
        var hotels = await _mediator.Send(new GetAllHotelsForAdminQuery(), cancellationToken);
        
        return Ok(hotels);
    }
    
    /// <summary>
    /// Deletes a specific hotel by ID.
    /// </summary>
    /// <param name="hotelId">The ID of the hotel to delete.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="204">Indicates that the hotel was successfully deleted.</response>
    /// <response code="400">If the deletion was unsuccessful or the hotel does not exist.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to delete the hotel.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete("{hotelId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteHotel(Guid hotelId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteHotelCommand { HotelId = hotelId };
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.IsSuccess ? NoContent() : BadRequest(result.ErrorMessage);
    }
    
    /// <summary>
    /// Creates a new hotel.
    /// </summary>
    /// <param name="hotelForCreationRequestDto">The hotel creation data.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="201">Returns the newly created hotel.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to create a hotel.</response>
    [ProducesResponseType(typeof(HotelForAdminResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.IsSuccess ? 
            CreatedAtAction(nameof(GetHotel), new { hotelId = result.Data.HotelId }, result.Data) 
            : BadRequest(result.ErrorMessage);
    }

    /// <summary>
    /// Updates details of an existing hotel.
    /// </summary>
    /// <param name="hotelId">The ID of the hotel to update.</param>
    /// <param name="hotelForUpdateRequestDto">The updated hotel data.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns the updated hotel data.</response>
    /// <response code="400">If the update is unsuccessful due to invalid data.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to update the hotel.</response>
    [ProducesResponseType(typeof(HotelForAdminResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
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
        
        var result = await _mediator.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
    }
}