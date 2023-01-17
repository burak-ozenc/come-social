using ComeSocial.Application.Common.Interfaces.Persistence;
using MediatR;
using ErrorOr;
using ComeSocial.Domain.SocialEvent.Entities;

namespace ComeSocial.Application.SocialEvent.Commands;

public class CreateSocialEventHandler : IRequestHandler<CreateSocialEventCommand, Domain.SocialEvent.SocialEvent>
{
    private readonly ISocialEventRepository _socialEventRepository;

    public CreateSocialEventHandler(ISocialEventRepository socialEventRepository)
    {
        _socialEventRepository = socialEventRepository;
    }

    public async Task<Domain.SocialEvent.SocialEvent> Handle(CreateSocialEventCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var socialEvent = Domain.SocialEvent.SocialEvent.CreateEvent(
            name: request.Name,
            subHeader: request.SubHeader,
            description: request.Description,
            date: request.Date,
            request.SocialEventTypes.Select(
                type => SocialEventType.Create(
                    type.Name,
                    type.SubTypes
                )).ToList(),
            request.Tags.Select(
                tag => Domain.Tag.Tag.CreateTag(
                    tag.Name
                )).ToList(),
            request.CreatedDateTime,
            request?.UpdatedDateTime
        );
        _socialEventRepository.Add(socialEvent);
        return socialEvent;
    }
}