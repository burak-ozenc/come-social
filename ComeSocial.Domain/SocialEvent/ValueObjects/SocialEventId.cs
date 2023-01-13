using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.Event.ValueObjects;

public sealed class EventId : ValueObject
{
    public Guid Value { get; }

    private EventId(Guid value)
    {
        Value = value;
    }

    public static EventId CreateUnique() => new(Guid.NewGuid());
    
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}