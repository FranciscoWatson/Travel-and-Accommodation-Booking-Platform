using System.Security.Authentication;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TABP.Application.Commands.Authentication;
using TABP.Application.DTOs.Authentication;

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
    public async Task<ActionResult<object>> Login(LoginRequestBody loginRequestBody)
    {
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