using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.ComeEventType;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class ComeEventTypeRepository : IComeEventTypeRepository
{
    private readonly ComeSocialDbContext _dbContext;

    public ComeEventTypeRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(ComeEventType socialEventType)
    {
        _dbContext.Add(socialEventType);
        _dbContext.SaveChanges();
    }
}