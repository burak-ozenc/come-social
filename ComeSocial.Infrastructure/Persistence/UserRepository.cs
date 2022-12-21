using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Entities;

namespace ComeSocial.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    
    public void  AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(c => c.Email == email);
    }
}