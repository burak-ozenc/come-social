using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Event.ValueObjects;
using ComeSocial.Domain.Group.ValueObjects;


namespace ComeSocial.Domain.Group;

public sealed class Group : AggregateRoot<GroupId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime EventDate { get; }
    public string GroupAvatar { get; }
    // convert to IList or IReadOnly
    public List<User.User> Users { get; }
    public EventId EventId { get; }
    public DateTime? CreatedDateTime { get; }
    public DateTime? UpdatedDateTime { get; }

    public Group(GroupId groupId,
        string name,
        string description,
        DateTime eventDate,
        string groupAvatar,
        List<User.User> users,
        EventId eventId) : base(groupId)
    {
        Name = name;
        Description = description;
        EventDate = eventDate;
        GroupAvatar = groupAvatar;
        Users = users;
        EventId = eventId;
    }

    public static Group CreateGroup(GroupId groupId,
        string name,
        string description,
        DateTime eventDate,
        string groupAvatar,
        List<User.User> users,
        EventId eventId)
        => new(groupId, name, description, eventDate, groupAvatar, users, eventId);

}