using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.SocialEvent.ValueObjects;

public sealed class SocialEventTypeId : ValueObject
{
    public Guid Value { get; }

    private SocialEventTypeId(Guid value)
    {
        Value = value;
    }

    public static SocialEventTypeId CreateUnique() => new (Guid.NewGuid());

    public static SocialEventTypeId Create(Guid value) => new(value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}