using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ComeSocial.Infrastructure.Services;

public class UserService : IUserService
{
    
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;
    

    public UserService(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    public async Task<ApplicationUser> CreateUser(ApplicationUser user)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(user.Email) != null)
            throw new NotImplementedException();
        
        var createUserResult = await _userManager.CreateAsync(user, user.Password);
        if(createUserResult.Succeeded)
            return user;

        // HANDLE ERRORS
        throw new NotImplementedException();
    }

    public ApplicationUser GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }
}