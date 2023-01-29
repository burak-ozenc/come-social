using ComeSocial.Domain.ComeEventType.ValueObjects;
using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Domain.SocialEvent;

public sealed class SocialEvent : AggregateRoot<SocialEventId>
{
    private readonly List<ComeEventTypeId> _comeEventTypes = new();
    private readonly List<TagId> _tags = new();
    
    public string Name { get; private set; }
    public string SubHeader { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    // security tips
    // convert to IList
    // after implementing the ef core
    public List<ComeEventTypeId> ComeEventTypes => _comeEventTypes;
    public List<TagId> Tags => _tags;

    private SocialEvent(SocialEventId id, 
        string name, 
        string subHeader,
        string description,
        DateTime date,
        List<ComeEventTypeId> comeEventTypes,
        List<TagId> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime 
        ) : base(id)
    {
        Name = name;
        SubHeader = subHeader;
        Description = description;
        Date = date;
        _comeEventTypes = comeEventTypes;
        _tags = tags;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static SocialEvent Create(
        string name,
        string subHeader,
        string description,
        DateTime date,
        List<ComeEventTypeId> comeEventTypes,
        List<TagId> tags,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) 
        => new(SocialEventId.CreateUnique(), 
            name, 
            subHeader, 
            description,
            date,
            comeEventTypes,
            tags,
            createdDateTime: DateTime.Now,
            updatedDateTime: null);
    
    private SocialEvent(){}
    
}