using ComeSocial.Domain.Common.Authentication;

namespace ComeSocial.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task AddUser(ApplicationUser user);
    ApplicationUser GetUserByEmail(string email);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<bool> IsEmailUnique(string email);

}