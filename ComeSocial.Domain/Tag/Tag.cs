using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Interest.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.Tag;

public sealed class Tag : AggregateRoot<TagId>
{
    // private readonly List<InterestId> _interests = new();
    public string Name { get; private set; }
    // public List<InterestId> Interests => _interests;
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    private Tag(TagId id, 
        string name,
        // List<InterestId> interests,
        DateTime? createdDateTime,
        DateTime? updatedDateTime 
        ) : base(id)
    {
        Name = name;
        // _interests = interests;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Tag CreateTag(
        string name,
        // List<InterestId> interests
        DateTime? createdDateTime,
        DateTime? updatedDateTime = null
        )
    {
        return new(
            TagId.CreateUnique(), 
            name,
            // interests,
            createdDateTime,
            updatedDateTime
            );
    }
    
    private Tag(){}
}