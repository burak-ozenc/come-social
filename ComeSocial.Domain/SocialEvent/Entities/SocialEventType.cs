using ComeSocial.Domain.Common.Enums;

namespace ComeSocial.Domain.SocialEvent.Entities;

public sealed class SocialEventType 
{
    public string Name { get; }
    // refactor this prop
    public List<string> SubTypes { get; }
    

    public SocialEventType(
        string name,
        List<string> subTypes)
    {
        Name = name;
        SubTypes = subTypes;
    }

    public static SocialEventType Create(
        string name,
        List<string> subTypes) 
        => new(name, subTypes);
}