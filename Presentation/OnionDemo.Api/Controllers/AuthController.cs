using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Features.Auth.Command.Login;
using OnionDemo.Application.Features.Auth.Command.RefreshToken;
using OnionDemo.Application.Features.Auth.Command.Register;

namespace OnionDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await _mediator.Send(request);
        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
