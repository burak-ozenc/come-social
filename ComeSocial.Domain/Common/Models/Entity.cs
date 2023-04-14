namespace ComeSocial.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
where TId : notnull
{
    public TId MessageId { get; protected set; }

    protected Entity(TId messageId)
    {
        MessageId = messageId;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && MessageId.Equals(entity.MessageId);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return MessageId.GetHashCode();
    }
    protected Entity() {}
}