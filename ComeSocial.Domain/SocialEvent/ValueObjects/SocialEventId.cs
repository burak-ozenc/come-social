using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.SocialEvent.ValueObjects;

public sealed class SocialEventId : ValueObject
{
    public Guid Value { get; }

    private SocialEventId(Guid value)
    {
        Value = value;
    }

    public static SocialEventId CreateUnique() => new(Guid.NewGuid());
    
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}