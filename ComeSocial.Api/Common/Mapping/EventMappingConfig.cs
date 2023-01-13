using ComeSocial.Application.SocialEvent.Commands;
using Mapster;

namespace ComeSocial.Api.Common.Mapping;

public class EventMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSocialEventRequest, CreateSocialEventCommand>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.SubHeader, src => src.SubHeader)
            .Map(dest => dest.Date, src => src.Date)
            .Map(dest => dest.Tags, src => src.Tags)
            .Map(dest => dest.EventTypes, src => src.EventTypes);
    }
}