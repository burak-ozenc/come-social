using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.Group.ValueObjects;

public sealed class GroupId : ValueObject
{
    public Guid Value { get; set; }

    private GroupId(Guid value)
    {
        Value = value;
    }

    public static GroupId CreateUnique() => new(Guid.NewGuid());
    
    public static GroupId Create(Guid value) => new GroupId(value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private GroupId(){}
}