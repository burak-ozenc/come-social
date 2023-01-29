using ComeSocial.Application.Contracts.SocialEvent;
using ComeSocial.Application.SocialEvent.Commands.CreateSocialEvent;
using ComeSocial.Domain.ComeEventType.ValueObjects;
using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.Tag.ValueObjects;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class SocialEventMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<CreateSocialEventRequest, CreateSocialEventCommand>()
            .Map(dest => dest.Tags, 
                src => src.Tags.ConvertAll(tagId => tagId.Id))
            .Map(dest => dest.ComeEventTypes, 
                src => src.SocialEventTypes.ConvertAll(cet => cet.Id));

        config.NewConfig<SocialEvent, CreateSocialEventResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Tags, 
                src => src.Tags.Select(tag => tag))
            .Map(dest => dest.ComeEventTypes, 
                src => src.ComeEventTypes.Select(cet => cet));

        config.NewConfig<TagId, SocialEventTagResponse>()
            .Map(dest => dest.Id, src => src.Value);

        config.NewConfig<ComeEventTypeId, ComeEventTypeResponse>()
            .Map(dest => dest.Id, src => src.Value);
    }
}