using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using ComeSocial.Domain.Group.ValueObjects;
using ComeSocial.Domain.User.ValueObjects;


namespace ComeSocial.Domain.Group;

public sealed class Group : AggregateRoot<GroupId>
{
    public readonly List<UserId> _users = new();
    // TODO
    // this field will be auto-filled with users' names
    // later can be changed to mutable field
    public string Name { get; private set; }
    public DateTime SocialEventDate { get; private set; }
    public string GroupAvatar { get; private set; }
    
    // TODO
    // security tips
    // convert to IList
    // after implementing the ef core
    public IReadOnlyList<UserId> Users => _users;
    public SocialEventId SocialEventId { get; private set; }
    public DateTime? CreatedDateTime { get; private set; }
    public DateTime? UpdatedDateTime { get; private set; }

    public Group(GroupId groupId,
        string name,
        DateTime socialEventDate,
        string groupAvatar,
        List<UserId> users,
        SocialEventId socialEventId,
        DateTime? createdDateTime,
        DateTime? updatedDateTime) : base(groupId)
    {
        Name = name;
        SocialEventDate = socialEventDate;
        GroupAvatar = groupAvatar;
        _users = users;
        SocialEventId = socialEventId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static Group CreateGroup(
        string name,
        string groupAvatar,
        DateTime socialEventDate,
        SocialEventId socialEventId,
        List<UserId> users)
        => new(
            GroupId.CreateUnique(), 
            name, 
            socialEventDate, 
            groupAvatar, 
            users, 
            socialEventId, 
            DateTime.Now,
            null);

    private Group(){}
}