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

    public static SocialEventId Create(Guid value) => new SocialEventId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
    private SocialEventId() { }
}