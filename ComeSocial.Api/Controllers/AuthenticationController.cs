using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Authentication.Queries.Login;
using ComeSocial.Application.Contracts.Authentication;
using ComeSocial.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ComeSocial.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        AuthenticationResult registerResult = await _mediator.Send(command);

        return Ok(_mapper.Map<AuthenticationResponse>(registerResult));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        AuthenticationResult loginResult = await _mediator.Send(query);

        return Ok(_mapper.Map<AuthenticationResponse>(loginResult));
    }
}