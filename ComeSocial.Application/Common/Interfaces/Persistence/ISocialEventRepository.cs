namespace ComeSocial.Application.Common.Interfaces.Persistence;

public interface ISocialEventRepository
{
    void Add(Domain.SocialEvent.SocialEvent socialEvent);
}