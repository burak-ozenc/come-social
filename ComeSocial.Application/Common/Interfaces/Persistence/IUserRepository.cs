using ComeSocial.Domain.Entities;

namespace ComeSocial.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    // private readonly List<User> _users;
    User? GetUserByEmail(string email);
    void AddUser(User user);
}