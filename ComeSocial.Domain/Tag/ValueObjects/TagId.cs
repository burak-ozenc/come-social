using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.Tag.ValueObjects;

public sealed class TagId : ValueObject
{
    public Guid Value { get; }
    
    
    private TagId(Guid value)
    {
        Value = value;
    }

    public static TagId CreateUnique() => new (Guid.NewGuid());

    public static TagId Create(Guid value) => new TagId(value); 
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private TagId(){}
}