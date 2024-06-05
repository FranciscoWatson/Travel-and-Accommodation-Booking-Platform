using System.Security.Authentication;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Authentication;
using TABP.Application.DTOs.Authentication;
using TABP.Application.Validators.AuthenticationValidators;

namespace Travel_and_Accommodation_Booking_Platform.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("authenticate")]
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