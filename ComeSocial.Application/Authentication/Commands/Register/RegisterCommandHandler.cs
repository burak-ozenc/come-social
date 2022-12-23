using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Common.Errors;
using ComeSocial.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ComeSocial.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validate the user if exists
        if (_userRepository.GetUserByEmail(command.Email) is null)
        {
            return Errors.User.DuplicateEmail;
        }

        // create a user & persist to db
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.AddUser(user);
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}