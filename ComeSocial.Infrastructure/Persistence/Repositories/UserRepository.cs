using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Common.Authentication;

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
        var _user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return _user != null ? _user : null;
    }


}