public record CreateSocialEventResponse(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<EventTypes> EventTypes,
    List<Tag>? Tags,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
);

public record EventType(
    EventTypes Type,
    List<string> SubTypes
);

public enum EventTypes
{
    Concert = 1,
    Theatre = 2,
    Cinema = 3
}
public record Tag(
    string Name
    );