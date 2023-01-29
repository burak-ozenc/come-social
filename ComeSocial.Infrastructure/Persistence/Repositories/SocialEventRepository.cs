using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.SocialEvent;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class SocialEventRepository :ISocialEventRepository
{
    private readonly ComeSocialDbContext _dbContext;

    public SocialEventRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(SocialEvent socialEvent)
    {
        _dbContext.Add(socialEvent);
        _dbContext.SaveChanges();
    }
}