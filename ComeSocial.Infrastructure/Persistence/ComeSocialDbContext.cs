using ComeSocial.Domain.Group;
using ComeSocial.Domain.SocialEvent;
using Microsoft.EntityFrameworkCore;
using Neo4j.Driver;

namespace ComeSocial.Infrastructure.Persistence;

public class ComeSocialDbContext : DbContext
{
    public ComeSocialDbContext(DbContextOptions<ComeSocialDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComeSocialDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}