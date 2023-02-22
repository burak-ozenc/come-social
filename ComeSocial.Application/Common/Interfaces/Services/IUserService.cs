using ComeSocial.Domain.Common.Authentication;
using FluentResults;

namespace ComeSocial.Application.Common.Interfaces.Services;

public interface IUserService
{
    Task<Result<ApplicationUser>> CreateUser(ApplicationUser user);
    ApplicationUser? GetUserByEmail(string email);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task<bool> IsEmailUnique(string email);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
}