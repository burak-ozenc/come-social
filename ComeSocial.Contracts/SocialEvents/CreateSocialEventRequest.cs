
public record CreateSocialEventRequest(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<EventType> EventTypes,
    List<Tag>? Tags
);
