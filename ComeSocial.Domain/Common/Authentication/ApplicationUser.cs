using Microsoft.AspNetCore.Identity;

namespace ComeSocial.Domain.Common.Authentication;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}