using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using FluentResults;
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
    public async Task<Result<ApplicationUser>> CreateUser(ApplicationUser user)
    {
        var createUserResult = await _userManager.CreateAsync(user, user.Password);

        if (createUserResult.Succeeded) return Result.Ok(user);
        var errors = createUserResult.Errors.Select(error => error.Code).ToList();

        return Result.Fail<ApplicationUser>(errors);

    }

    public ApplicationUser? GetUserByEmail(string email)
    {
        return _userRepository.GetUserByEmail(email);
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return await _userRepository.IsEmailUnique(email);
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
}