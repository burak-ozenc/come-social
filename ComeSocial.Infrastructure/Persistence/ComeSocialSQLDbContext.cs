using ComeSocial.Domain.SocialEvent;
using Microsoft.EntityFrameworkCore;

namespace ComeSocial.Infrastructure.Persistence;

public class ComeSocialSQLDbContext : DbContext
{
    public ComeSocialSQLDbContext(DbContextOptions<ComeSocialSQLDbContext> options ) : base(options){}
    
    public DbSet<SocialEvent> SocialEvents { get; set; }
    
}