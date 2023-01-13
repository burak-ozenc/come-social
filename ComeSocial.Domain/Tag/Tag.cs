using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.Tag;

public sealed class Tag : AggregateRoot<TagId>
{
    public string Name { get; }
    public DateTime? CreatedDateTime { get; }
    public DateTime? UpdatedDateTime { get; }

    private Tag(TagId id, string name) : base(id)
    {
        Name = name;
    }

    public static Tag CreateTag(string name)
    {
        return new(TagId.CreateUnique(), name);
    }
}