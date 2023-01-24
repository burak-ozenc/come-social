using ComeSocial.Domain.Tag.ValueObjects;

namespace ComeSocial.Application.Contracts.SocialEvent;

public record CreateSocialEventRequest
(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<SocialEventTypesRequest> SocialEventTypes,
    List<SocialEventTagRequest> Tags
);

public record SocialEventTagRequest(
    string Id);

public record SocialEventTypesRequest(
    string Id,
    string Name
    );