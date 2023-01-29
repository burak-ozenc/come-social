using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Domain.Common.Errors;
using MediatR;

namespace ComeSocial.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserService userService, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userService = userService;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Check user if exists
        if (_userService.GetUserByEmail(command.Email) is not null)
        {
            throw new NotImplementedException();
        }
        
        // create an user
        var user = new ApplicationUser()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.UserName,
            Email = command.Email
        };

        // persist to db
        
        // handle errors
        var result = _userService.CreateUser(user);

        // if (result.IsCompletedSuccessfully)
            _userRepository.AddUser(user);
        
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}