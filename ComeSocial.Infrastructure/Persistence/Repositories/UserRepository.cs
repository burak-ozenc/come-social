using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Common.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ComeSocialDbContext _dbContext;


    public UserRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddUser(ApplicationUser user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
    
    public ApplicationUser GetUserByEmail(string email)
    {
        return _dbContext.Users?.FirstOrDefault(u => u.Email == email);
    }
    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users?.FirstOrDefaultAsync(u => u.Email == email);
    }


}