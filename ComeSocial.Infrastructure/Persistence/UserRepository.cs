using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Entities;

namespace ComeSocial.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new List<User>();
    
    public void  AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(c => c.Email == email);
    }
}