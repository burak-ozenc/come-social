using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using FluentResults;
using MediatR;

namespace ComeSocial.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    private readonly IUserService _userService;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserService userService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userService = userService;
    }

    
    // TODO
    public async Task<AuthenticationResult> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        var user = _userService.GetUserByEmail(command.Email);
        // check if user exists
        if (user == null)
        {
            throw new NotImplementedException();
        }
        
        // validate user
        var result = await _userService.CheckPasswordAsync(user,command.Password);

        if (!result)
        {
            throw new NotImplementedException();
        }
        
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        // create and return new JWT token 
        return new AuthenticationResult(user, token);
    }
}