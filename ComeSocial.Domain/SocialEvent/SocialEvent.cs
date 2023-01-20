using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.Entities;
using ComeSocial.Domain.SocialEvent.ValueObjects;

namespace ComeSocial.Domain.SocialEvent;

public sealed class SocialEvent : AggregateRoot<SocialEventId>
{
    private readonly List<string> _socialEventTypes = new();
    private readonly List<string> _tags = new();
    
    public string Name { get; private set; }
    public string SubHeader { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    // security tips
    // convert to IList
    // after implementing the ef core
    public List<string> SocialEventTypes => _socialEventTypes;
    public IReadOnlyList<string> Tags => _tags.AsReadOnly();

    private SocialEvent(SocialEventId id, 
        string name, 
        string subHeader,
        string description,
        DateTime date,
        List<string> eventTypes,
        List<string> tags,
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
        DateTime date,
        List<string> eventType,
        List<string> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) 
        => new(SocialEventId.CreateUnique(), 
            name, 
            subHeader, 
            description,
            date,
            eventType,
            tags,
            createdDateTime: DateTime.Now,
            updatedDateTime: null);
    
    private SocialEvent(){}
    
}