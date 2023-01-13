using ComeSocial.Application.Common.Interfaces.Persistence;
using MediatR;
using ErrorOr;
using ComeSocial.Domain.Event.Entities;

namespace ComeSocial.Application.SocialEvent.Commands;

public class CreateSocialEventHandler : IRequestHandler<CreateSocialEventCommand, ErrorOr<Domain.Event.Event>>
{
    private readonly ISocialEventRepository _socialEventRepository;

    public CreateSocialEventHandler(ISocialEventRepository socialEventRepository)
    {
        _socialEventRepository = socialEventRepository;
    }

    public async Task<ErrorOr<Domain.SocialEvent.SocialEvent>> Handle(CreateSocialEventCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var socialEvent = Domain.SocialEvent.SocialEvent.CreateEvent(
            request.Name,
            request.SubHeader,
            request.Description,
            request.Date,
            request.EventTypes.Select(
                type => EventType.Create(
                    (Domain.Common.Enums.EventTypes)type.Type,
                    type.SubTypes
                )).ToList(),
            request.Tags.Select(
                tag => Domain.Tag.Tag.CreateTag(
                    tag.Name
                )).ToList()
        );
        _socialEventRepository.Add(socialEvent);
        return socialEvent;
    }
}