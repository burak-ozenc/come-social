using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Event.Entities;
using ComeSocial.Domain.Event.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.Event;

public sealed class Event : AggregateRoot<EventId>
{
    private readonly List<EventType> _eventTypes = new();
    private readonly List<Tag.Tag> _tags = new();
    
    public string Name { get; }
    public string SubHeader { get; }
    public string Description { get; }
    public DateTime? Date { get; }
    public DateTime? CreatedDateTime { get; }
    public DateTime? UpdatedDateTime { get; }

    public IReadOnlyList<EventType> EventTypes => _eventTypes.AsReadOnly();
    public IReadOnlyList<Tag.Tag> Tags => _tags.AsReadOnly();

    // public EventType EventType { get; }
    // public List<GroupId> GroupIds { get; }

    private Event(EventId id, 
        string name, 
        string subHeader,
        string description,
        DateTime? date,
        List<EventType> eventTypes,
        List<Tag.Tag> tags 
        ) : base(id)
    {
        Name = name;
        SubHeader = subHeader;
        Description = description;
        Date = date;
        _eventTypes = eventTypes;
        _tags = tags;
    }

    public static Event CreateEvent(
        string name,
        string subHeader,
        string description,
        DateTime? date,
        List<EventType> eventType,
        List<Tag.Tag> tags) 
        => new(EventId.CreateUnique(), 
            name, 
            subHeader, 
            description,
            date,
            eventType,
            tags);
}