using ComeSocial.Domain.ComeEventType;
using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Domain.Group;
using ComeSocial.Domain.Interest;
using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.Tag;
using ComeSocial.Infrastructure.Persistence.Configurations.IdentityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence;
    
public sealed class ComeSocialDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ComeSocialDbContext(DbContextOptions<ComeSocialDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ComeEventType> ComeSocialEventTypes { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComeSocialDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}