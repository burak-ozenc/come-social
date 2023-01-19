using MediatR;
using ErrorOr;


namespace ComeSocial.Application.SocialEvent.Commands;

public record CreateSocialEventCommand(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<SocialEventTypeCommand> SocialEventTypes,
    List<Tag> Tags,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    ) : IRequest<Domain.SocialEvent.SocialEvent>;


public record SocialEventTypeCommand(
    string Id,
    string Name,
    List<string> SubTypes
);


public record Tag(
    // string TagId,
    string Name
);