
public record CreateSocialEventRequest(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<string> SocialEventTypes,
    List<string>? Tags
);
