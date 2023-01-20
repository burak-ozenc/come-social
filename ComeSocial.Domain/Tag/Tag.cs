using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.Tag;

public sealed class Tag : AggregateRoot<TagId>
{
    public string Name { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    private Tag(TagId id, string name) : base(id)
    {
        Name = name;
    }

    public static Tag CreateTag(string name)
    {
        return new(TagId.CreateUnique(), name);
    }
    
    private Tag(){}
}