using MediatR;

namespace ComeSocial.Application.SocialEvent.Commands.CreateSocialEvent;

public record CreateSocialEventCommand(
    string Name,
    string SubHeader,
    string Description,
    DateTime Date,
    List<string> ComeEventTypes,
    List<string> Tags,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    ) : IRequest<Domain.SocialEvent.SocialEvent>;
    