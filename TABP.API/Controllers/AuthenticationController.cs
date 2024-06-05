using System.Security.Authentication;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Authentication;
using TABP.Application.DTOs.Authentication;
using TABP.Application.Validators.AuthenticationValidators;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Authenticates a user and returns a JWT token if successful.
    /// </summary>
    /// <param name="loginRequestBody">The login credentials.</param>
    /// <returns>Returns an access token and user information if authentication is successful.</returns>
    /// <response code="200">If the user is authenticated successfully.</response>
    /// <response code="401">If the user credentials are invalid.</response>
    /// <response code="400">If the login request body is invalid.</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequestBody loginRequestBody)
    {
        var validator = new LoginRequestBodyValidator();
        var result = await validator.ValidateAsync(loginRequestBody);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        
        try
        {
            var command = _mapper.Map<LoginCommand>(loginRequestBody);

            var loginResponse = await _mediator.Send(command);
            
            return Ok(loginResponse);

        }
        catch (AuthenticationException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
    
}