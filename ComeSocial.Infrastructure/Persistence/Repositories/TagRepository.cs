using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Tag;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ComeSocialDbContext _dbContext;

    public TagRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Tag tag)
    {
        _dbContext.Add(tag);
        _dbContext.SaveChanges();
    }
}