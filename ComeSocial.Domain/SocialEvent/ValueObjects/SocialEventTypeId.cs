using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.Event.ValueObjects;

public sealed class EventTypeId : ValueObject
{
    public Guid Value { get; }

    private EventTypeId(Guid value)
    {
        Value = value;
    }

    public static EventTypeId CreateUnique() => new (Guid.NewGuid());
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}