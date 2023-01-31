using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.SocialEvent.ValueObjects;
using ComeSocial.Domain.User.ValueObjects;
using MediatR;

namespace ComeSocial.Application.Group.Commands.CreateGroupCommand;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Domain.Group.Group>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Domain.Group.Group> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var group = Domain.Group.Group.CreateGroup(
            name: request.Name,
            groupAvatar: request.GroupAvatar,
            socialEventId: SocialEventId.Create(Guid.Parse(request.SocialEventId)),
            socialEventDate: request.SocialEventDate,
            users: request.UserIds.ConvertAll(u => UserId.Create(Guid.Parse(u)))
        );

        _groupRepository.Add(group);

        return group;
    }
}