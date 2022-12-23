using ComeSocial.Application.Authentication.Commands.Register;
using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Common.Errors;
using ComeSocial.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ComeSocial.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(command.Email) is not User user)
        {
            return ErrorsAuthentication.Authentication.InvalidCredentials;
        }

        // validate the params
        if (user.Password != command.Password)
        {
            return ErrorsAuthentication.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(
            new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            });

        // create new JWT token 
        return new AuthenticationResult(user, token);
    }
}