using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.User.ValueObjects;

namespace ComeSocial.Domain.User;


// whole class will be adapted to identity service base user  
public sealed class User : AggregateRoot<UserId> 
{
    public string FirstName { get; private set;  }
    public string LastName { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    
    public User(UserId id,
        string firstName,
        string lastName,
        string userName,
        string email,
        string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
    }

    
    public static User CreateUser(
        UserId id,
        string firstName,
        string lastName,
        string userName,
        string email,
        string password)
    {
        return new User(id, firstName, lastName, userName, email, password);
    }
    
    private User(){}
}