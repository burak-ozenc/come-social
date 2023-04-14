namespace ComeSocial.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
where TId : notnull
{
    protected AggregateRoot(TId messageId) : base(messageId)
    {
    }
    protected AggregateRoot(){}
}