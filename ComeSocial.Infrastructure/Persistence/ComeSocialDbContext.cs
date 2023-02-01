using ComeSocial.Domain.ComeEventType;
using ComeSocial.Domain.Common.Authentication;
<<<<<<< HEAD
using ComeSocial.Domain.Group;
=======
>>>>>>> 3859e355bf2b322bb20dc646a539f83c4f807a39
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
<<<<<<< HEAD
    public DbSet<Group> Groups { get; set; }
=======
>>>>>>> 3859e355bf2b322bb20dc646a539f83c4f807a39

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComeSocialDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}