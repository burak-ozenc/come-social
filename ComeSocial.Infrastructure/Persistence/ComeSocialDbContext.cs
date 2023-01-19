using ComeSocial.Domain.SocialEvent;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence;

public class ComeSocialDbContext : DbContext
{
    public ComeSocialDbContext(DbContextOptions<ComeSocialDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    
    
    
}