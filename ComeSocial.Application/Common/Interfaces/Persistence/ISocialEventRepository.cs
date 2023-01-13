namespace ComeSocial.Application.Common.Interfaces.Persistence;

public interface IEventRepository
{
    void Add(Domain.Event.Event @event);
}