using ComeSocial.Domain.ComeEventType;
using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.Tag;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence;

public sealed class ComeSocialDbContext : DbContext
{
    public ComeSocialDbContext(DbContextOptions<ComeSocialDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ComeEventType> ComeSocialEventTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComeSocialDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}