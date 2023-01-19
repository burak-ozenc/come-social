using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.ValueObjects;

namespace ComeSocial.Domain.SocialEvent.Entities;

public sealed class SocialEventType :Entity<SocialEventTypeId>
{
    public string Name { get; }
    // refactor this prop
    public List<string> SubTypes { get; }
    

    public SocialEventType(
        SocialEventTypeId id,
        string name,
        List<string> subTypes
        ) : base(id)
    {
        Name = name;
        SubTypes = subTypes;
    }

    public static SocialEventType Create(
        string name,
        List<string> subTypes) 
        => new(SocialEventTypeId.CreateUnique(), 
            name, 
            subTypes
            );
}