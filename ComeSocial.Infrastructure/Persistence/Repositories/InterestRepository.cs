using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Contracts.Interest;
using ComeSocial.Domain.Interest;

namespace ComeSocial.Infrastructure.Persistence.Repositories;

public class InterestRepository : IInterestRepository
{
    private readonly ComeSocialDbContext _dbContext;

    public InterestRepository(ComeSocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Interest interest)
    {
        _dbContext.Add(interest);
        _dbContext.SaveChanges();
    }
}