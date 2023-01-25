using ComeSocial.Domain.ComeEventType;
using ComeSocial.Domain.Interest;
using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.Tag;
using ComeSocial.Infrastructure.Models;
using ComeSocial.Infrastructure.Persistence.Configurations.IdentityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence;

public sealed class ComeSocialDbContext : IdentityDbContext<ApplicationUser>
{
    public ComeSocialDbContext(DbContextOptions<ComeSocialDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ComeEventType> ComeSocialEventTypes { get; set; }
    public DbSet<Interest> Interests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComeSocialDbContext).Assembly);
        
        modelBuilder.ApplyConfiguration(new RolesConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}