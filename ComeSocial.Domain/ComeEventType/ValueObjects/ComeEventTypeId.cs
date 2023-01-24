using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.ComeEventType.ValueObjects;

public class ComeEventTypeId : ValueObject
{
    public Guid Value { get; }

    private ComeEventTypeId(Guid value)
    {
        Value = value;
    }

    public static ComeEventTypeId CreateUnique() => new(Guid.NewGuid());

    public static ComeEventTypeId Create(Guid value) => new ComeEventTypeId(value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private ComeEventTypeId() {}
}