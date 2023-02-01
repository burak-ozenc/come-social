using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

<<<<<<< HEAD
    public static UserId CreateUnique() => new(Guid.NewGuid());

    public static UserId Create(Guid value) => new UserId(value);
=======
    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
>>>>>>> 3859e355bf2b322bb20dc646a539f83c4f807a39
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
}