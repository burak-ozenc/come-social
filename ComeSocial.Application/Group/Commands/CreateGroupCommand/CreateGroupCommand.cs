using MediatR;

namespace ComeSocial.Application.Group.Commands.CreateGroupCommand;

public record CreateGroupCommand(
    string Name,
    string GroupAvatar,
    string SocialEventId,
    DateTime SocialEventDate,
    List<string> UserIds,
    DateTime? UpdatedDateTime,
    DateTime? CreatedDateTime
    ) : IRequest<Domain.Group.Group>;