
public record CreateSocialEventRequest(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<SocialEventTypeResponse> SocialEventTypes,
    List<TagResponse>? Tags
);
