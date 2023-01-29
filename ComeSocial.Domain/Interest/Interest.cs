using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Interest.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.Interest;

public sealed class Interest : AggregateRoot<InterestId>
{
    private readonly List<TagId> _tags = new();
    
    public string Name { get; private set;  }
    public IReadOnlyList<TagId> Tags => _tags.AsReadOnly();
    public DateTime? CreatedDateTime { get; private set;  }
    public DateTime? UpdatedDateTime { get; private set;  }
    
    public Interest(
        InterestId id,
        string name,
        List<TagId> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime
        ) : base(id)
    {
        Name = name;
        _tags = tags;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Interest CreateInterest(
        string name,
        List<TagId> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) =>
        new(
            InterestId.CreateUnique(),
            name,
            tags,
            createdDateTime,
            updatedDateTime
        );
    private Interest(){}
}