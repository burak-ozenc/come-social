using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }
    
    public static UserId CreateUnique() => new(Guid.NewGuid());

    public static UserId Create(Guid value) => new UserId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}