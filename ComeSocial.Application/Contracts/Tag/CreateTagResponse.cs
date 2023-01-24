namespace ComeSocial.Application.Contracts.Tag;

public record CreateTagResponse(
    string Id,
    string Name,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    );