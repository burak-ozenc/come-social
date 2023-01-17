using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.SocialEvent;

namespace ComeSocial.Infrastructure.Persistence;

public class SocialEventRepository :ISocialEventRepository
{
    private static readonly List<SocialEvent> _socialEvents = new();
    public void Add(SocialEvent socialEvent)
    {
        _socialEvents.Add(socialEvent);
    }
}