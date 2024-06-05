using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Cities;
using TABP.Application.DTOs.CityDTOs;
using TABP.Application.Queries.Cities;
using TABP.Application.Validators.CityValidators;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;


[ApiController]
[Route("/api/cities")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CitiesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves details for a single city by ID.
    /// </summary>
    /// <param name="cityId">The ID of the city to retrieve.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns the city details.</response>
    /// <response code="404">If no city is found with the provided ID.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the city.</response>
    /// <returns>The Requested City By ID.</returns>
    [ProducesResponseType(typeof(CityForAdminDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet("{cityId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CityForAdminDto>> GetCity(Guid cityId, CancellationToken cancellationToken = default)
    {
        var query = new GetCityByIdQuery { CityId = cityId };
        
        var city = await _mediator.Send(query, cancellationToken);
        
        return city == null ? NotFound() : Ok(city);
    }
    
    /// <summary>
    /// Retrieves a list of all cities.
    /// </summary>
    /// <response code="200">Returns a list of cities.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to view the cities.</response>
    /// <returns>A list of all cities.</returns>
    [ProducesResponseType(typeof(IEnumerable<CityForAdminDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<CityForAdminDto>>> GetCities(CancellationToken cancellationToken = default)
    {
        var query = new GetCitiesQuery();
        
        var cities = await _mediator.Send(query, cancellationToken);
        
        return Ok(cities);
    }

    /// <summary>
    /// Retrieves Trending Cities.
    /// </summary>
    /// <param name="count">The number of trending cities to retrieve.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="200">Returns a list of trending cities.</response>
    /// <returns>A list of trending cities</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("trending")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<TrendingCityResponseDto>>> GetTrendingCities(int count = 5,
        CancellationToken cancellationToken = default)
    {
        var query = new GetTrendingCitiesQuery(count);
        
        var cities = await _mediator.Send(query, cancellationToken);
        
        return Ok(cities);
    }
    
    /// <summary>
    /// Creates a new city. 
    /// </summary>
    /// <param name="cityForCreationRequestDto">The information of the new city.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<CityForCreationResponseDto>> CreateCity(CityForCreationRequestDto cityForCreationRequestDto, CancellationToken cancellationToken = default)
    {
        var validator = new CityForCreationRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(cityForCreationRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = _mapper.Map<CreateCityCommand>(cityForCreationRequestDto);
        var city = await _mediator.Send(command, cancellationToken);
        
        return CreatedAtAction(nameof(GetCity), new { cityId = city.CityId }, city);
    }
    
    
    /// <summary>
    /// Updates a city. 
    /// </summary>
    /// <param name="cityId">The ID of the city to update.</param>
    /// <param name="cityForUpdateRequestDto">The city data to update which includes name, description, etc.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="204">If the city is successfully updated.</response>
    /// <response code="400">If the request data is invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to update the city.</response>
    /// <response code="404">If the city is not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{cityId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateCity(Guid cityId, CityForUpdateRequestDto cityForUpdateRequestDto, CancellationToken cancellationToken = default)
    {
        var validator = new CityForUpdateRequestDtoValidator();
        var validationResult = await validator.ValidateAsync(cityForUpdateRequestDto, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var command = new UpdateCityCommand { CityId = cityId };
        _mapper.Map(cityForUpdateRequestDto, command);
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }
        return NoContent();
    }
    
    /// <summary>
    /// Deletes a city.
    /// </summary>
    /// <param name="cityId">The ID of the city to update.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <response code="204">If the city is successfully deleted.</response>
    /// <response code="400">If the request data is invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized to update the city.</response>
    /// <response code="404">If the city is not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    [HttpDelete("{cityId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteCity(Guid cityId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteCityCommand { CityId = cityId };
        
        var result = await _mediator.Send(command, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }
        return NoContent();
    }
}