using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Entities;

namespace ComeSocial.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = _userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Validate the user if exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("Email already exists");
        }

        // create a user & persist to db
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        _userRepository.AddUser(user);
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName,lastName);
        
        return new AuthenticationResult(user.Id, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // validate user 
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Email already exists");
        }
        
        // validate the params
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        // create new JWT token 
        return new AuthenticationResult(
            user.Id,
            user.FirstName, 
            user.LastName,
            email, 
            token);
    }
}