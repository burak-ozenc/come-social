using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using ComeSocial.Domain.Group.ValueObjects;


namespace ComeSocial.Domain.Group;

public sealed class Group : AggregateRoot<GroupId>
{
    // this field will be auto-filled with users' names
    // later can be changed to mutable field
    public string Name { get; private set; }
    public DateTime SocialEventDate { get; private set; }
    public string GroupAvatar { get; private set; }
    
    // security tips
    // convert to IList
    // after implementing the ef core
    public List<User.User> Users { get; private set; }
    public SocialEventId SocialEventId { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    public Group(GroupId groupId,
        string name,
        DateTime eventDate,
        string groupAvatar,
        List<User.User> users,
        SocialEventId socialEventId,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) : base(groupId)
    {
        Name = name;
        SocialEventDate = eventDate;
        GroupAvatar = groupAvatar;
        Users = users;
        SocialEventId = socialEventId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Group CreateGroup(GroupId groupId,
        string name,
        DateTime eventDate,
        string groupAvatar,
        List<User.User> users,
        SocialEventId eventId)
        => new(groupId, name, eventDate, groupAvatar, users, eventId, DateTime.Now,null);

    private Group(){}
}