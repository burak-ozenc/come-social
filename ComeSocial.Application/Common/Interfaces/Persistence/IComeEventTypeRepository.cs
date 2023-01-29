namespace ComeSocial.Application.Common.Interfaces.Persistence;

public interface IComeEventTypeRepository
{
    void Add(Domain.ComeEventType.ComeEventType socialEventType);
}