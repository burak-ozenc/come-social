using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Authentication.Queries.Login;
using ComeSocial.Application.Common.Errors;
using ComeSocial.Application.Contracts.Authentication;
using FluentResults;
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
        RegisterCommand command = _mapper.Map<RegisterCommand>(request);
        
        Result<AuthenticationResult> registerResult = await _mediator.Send(command);

        if (registerResult.IsSuccess) 
            return Ok(_mapper.Map<AuthenticationResponse>(registerResult.Value));
        
        var firstError = registerResult.Errors[0];
        if (firstError is DuplicateEmailError)
        {
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Message);
        }

        // TODO
        return Problem();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        AuthenticationResult loginResult = await _mediator.Send(query);

        return Ok(_mapper.Map<AuthenticationResponse>(loginResult));
    }
}