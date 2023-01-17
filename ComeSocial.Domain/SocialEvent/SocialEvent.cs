using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.Entities;
using ComeSocial.Domain.SocialEvent.ValueObjects;

namespace ComeSocial.Domain.SocialEvent;

public sealed class SocialEvent : AggregateRoot<SocialEventId>
{
    private readonly List<SocialEventType> _socialEventTypes = new();
    private readonly List<Tag.Tag> _tags = new();
    
    public string Name { get; }
    public string SubHeader { get; }
    public string Description { get; }
    public DateTime? Date { get; }
    public DateTime? CreatedDateTime { get; }
    public DateTime? UpdatedDateTime { get; }

    // security tips
    // convert to IList
    // after implementing the ef core
    public IReadOnlyList<SocialEventType> SocialEventTypes => _socialEventTypes.AsReadOnly();
    public IReadOnlyList<Tag.Tag> Tags => _tags.AsReadOnly();

    private SocialEvent(SocialEventId id, 
        string name, 
        string subHeader,
        string description,
        DateTime? date,
        List<SocialEventType> eventTypes,
        List<Tag.Tag> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime 
        ) : base(id)
    {
        Name = name;
        SubHeader = subHeader;
        Description = description;
        Date = date;
        _socialEventTypes = eventTypes;
        _tags = tags;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static SocialEvent CreateEvent(
        string name,
        string subHeader,
        string description,
        DateTime? date,
        List<SocialEventType> eventType,
        List<Tag.Tag> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) 
        => new(SocialEventId.CreateUnique(), 
            name, 
            subHeader, 
            description,
            date,
            eventType,
            tags,
            DateTime.Now
            , null);
}