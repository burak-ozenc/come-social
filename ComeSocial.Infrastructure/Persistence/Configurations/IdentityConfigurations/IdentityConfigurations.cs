using ComeSocial.Domain.Common.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComeSocial.Infrastructure.Persistence.Configurations.IdentityConfigurations;

internal sealed class IdentityConfigurations : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        ConfigureIdentityUserTable(builder);
    }
    
    private void ConfigureIdentityUserTable(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Ignore(u => u.Password);
    }

}