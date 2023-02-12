using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Errors;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using FluentResults;
using MediatR;

namespace ComeSocial.Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserService userService,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userService = userService;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userService.IsEmailUnique(command.Email) is false)
        {
            return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
        }

        var user = new ApplicationUser
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.UserName,
            Email = command.Email,
            Password = command.Password
        };
        
        var result = await _userService.CreateUser(user);

        if(result.IsSuccess)
        {
            var token = _jwtTokenGenerator.GenerateToken(user);

            return Result.Ok(new AuthenticationResult(user, token));
        }
        
        var errors = result.Errors.Select(error => error.Message);
        
        return Result.Fail<AuthenticationResult>(errors);


    }
}