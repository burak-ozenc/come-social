using ComeSocial.Domain.Common.Authentication;

namespace ComeSocial.Application.Common.Interfaces.Services;

public interface IUserService
{
    Task<ApplicationUser> CreateUser(ApplicationUser user);
    ApplicationUser? GetUserByEmail(string email);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
}