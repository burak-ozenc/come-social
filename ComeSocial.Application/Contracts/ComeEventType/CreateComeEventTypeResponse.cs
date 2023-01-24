namespace ComeSocial.Application.Contracts.ComeEventType;

public record CreateComeEventTypeResponse(
    string Id,
    string Name,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    );