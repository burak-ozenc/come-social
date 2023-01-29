using ComeSocial.Application.Authentication.Common;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ComeSocial.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, UserManager<ApplicationUser> userManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _userManager = userManager;
    }

    
    // FIX LOGIN QUERY
    public async Task<AuthenticationResult> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // check if user exists
        if (_userRepository.GetUserByEmail(command.Email) is not ApplicationUser user)
        {
            throw new NotImplementedException();
            // return ErrorsAuthentication.Authentication.InvalidCredentials;
        }
        
        // validate user
        var result = _userManager.CheckPasswordAsync(user,command.Password);

        if (!result.Result)
        {
            throw new NotImplementedException();
        }
        
        
        var token = _jwtTokenGenerator.GenerateToken(
            new ApplicationUser()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        
        // // create and return new JWT token 
        return new AuthenticationResult(user, token);
    }
}