namespace ComeSocial.Application.Contracts.Group;

public record CreateGroupRequest(
    string Name,
    string GroupAvatar,
    string SocialEventId,
    DateTime SocialEventDate,
    List<GroupUsersRequest> Users);
    
    
public record GroupUsersRequest(string Id);