namespace ComeSocial.Application.Contracts.Group;

public record CreateGroupRequest(
    string Name,
    string GroupAvatar,
    GroupSocialEventIdResponse SocialEventId,
    DateTime SocialEventDate,
    List<GroupUsersRequest> UserIds);
    
    
public record GroupUsersRequest(string Value);
public record GroupSocialEventIdResponse(string Value);