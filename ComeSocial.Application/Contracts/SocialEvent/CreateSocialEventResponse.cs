namespace ComeSocial.Application.Contracts.SocialEvent;

public record CreateSocialEventResponse(
    string Id,
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<ComeEventTypeResponse> ComeEventTypes,
    List<SocialEventTagResponse> Tags,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    );
    
public record SocialEventTagResponse(
    string Id,
    string Name);
public record ComeEventTypeResponse(
    string Id,
    string Name);