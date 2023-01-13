using ComeSocial.Domain.Common.Enums;
using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Event.ValueObjects;

namespace ComeSocial.Domain.Event.Entities;

public sealed class EventType 
{
    public EventTypes Name { get; }
    // refactor this prop
    public List<string> SubTypes { get; }
    

    public EventType(
        EventTypes name,
        List<string> subTypes)
    {
        Name = name;
        SubTypes = subTypes;
    }

    public static EventType Create(
        EventTypes name,
        List<string> subTypes) 
        => new(name, subTypes);
}