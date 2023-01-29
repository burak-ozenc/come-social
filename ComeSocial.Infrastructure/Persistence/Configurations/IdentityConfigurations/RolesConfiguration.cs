using Microsoft.AspNetCore.Identity;

namespace ComeSocial.Infrastructure.Persistence.Configurations.IdentityConfigurations;

public class ApplicationRole : IdentityRole<Guid>
{
    public string Description { get; set; }
}