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

<<<<<<< HEAD
    public static GroupId Create(Guid value) => new GroupId(value);

=======
>>>>>>> 3859e355bf2b322bb20dc646a539f83c4f807a39
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    private GroupId(){}
}