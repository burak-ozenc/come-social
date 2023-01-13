using MediatR;
using ErrorOr;


namespace ComeSocial.Application.SocialEvent.Commands;

public record CreateSocialEventCommand(
    string Name,
    string SubHeader,
    string Description,
    DateTime? Date,
    List<EventTypeCommand> EventTypes,
    List<Tag>? Tags,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime) : IRequest<ErrorOr<Domain.SocialEvent.SocialEvent>>;


public record EventTypeCommand(
    EventTypes Type,
    List<string> SubTypes
);

public enum EventTypes
{
    Concert,
    Theatre = 1,
    Cinema = 2
}

public record Tag(
    string Value,
    string Name
);