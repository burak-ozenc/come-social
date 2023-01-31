using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.Group;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly ComeSocialDbContext _dbContext;

    public GroupRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Group group)
    {
        _dbContext.Add(group);
        _dbContext.SaveChanges();
    }
}