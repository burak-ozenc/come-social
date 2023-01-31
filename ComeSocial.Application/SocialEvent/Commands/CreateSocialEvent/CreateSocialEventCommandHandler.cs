using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Domain.ComeEventType.ValueObjects;
using ComeSocial.Domain.Tag.ValueObjects;
using MediatR;

namespace ComeSocial.Application.SocialEvent.Commands.CreateSocialEvent;

public class CreateSocialEventHandler : IRequestHandler<CreateSocialEventCommand, Domain.SocialEvent.SocialEvent>
{
    private readonly ISocialEventRepository _socialEventRepository;

    public CreateSocialEventHandler(ISocialEventRepository socialEventRepository)
    {
        _socialEventRepository = socialEventRepository;
    }

    public async Task<Domain.SocialEvent.SocialEvent> Handle(CreateSocialEventCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var socialEvent = Domain.SocialEvent.SocialEvent.Create(
            name: request.Name,
            subHeader: request.SubHeader,
            description: request.Description,
            date: request.Date,
            comeEventTypes: request.ComeEventTypes
                .ConvertAll(t => ComeEventTypeId.Create(Guid.Parse(t))),
            tags: request.Tags
                .ConvertAll(t => TagId.Create(Guid.Parse(t))),
            createdDateTime: DateTime.Now, 
            updatedDateTime: request.UpdatedDateTime
        );
        
        _socialEventRepository.Add(socialEvent);
        
        return socialEvent;
    }
}