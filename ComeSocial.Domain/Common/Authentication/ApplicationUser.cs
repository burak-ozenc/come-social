using Microsoft.AspNetCore.Identity;

namespace ComeSocial.Domain.Common.Authentication;

public  class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }

    public ApplicationUser(
        string userName,
        string email,
        string firstName,
        string lastName,
        string password)
    {
        UserName = userName;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }
    
    public static ApplicationUser CreateUser(
        string userName,
        string email,
        string firstName,
        string lastName,
        string password)
    {
        return new ApplicationUser(userName,email, firstName, lastName, password);
    }
    
    private ApplicationUser() {}
}