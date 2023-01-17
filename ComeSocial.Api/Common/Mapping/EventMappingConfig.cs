using ComeSocial.Application.SocialEvent.Commands;
using ComeSocial.Domain.SocialEvent;
using ComeSocial.Domain.SocialEvent.Entities;
using Mapster;

namespace ComeSocial.Api.Common.Mapping;

public class SocialEventMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        try
        {
            config.NewConfig<CreateSocialEventRequest, CreateSocialEventCommand>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.SubHeader, src => src.SubHeader)
                .Map(dest => dest.Date, src => src.Date)
                .Map(dest => dest.Tags, src => src.Tags)
                .Map(dest => dest.SocialEventTypes, src => src.SocialEventTypes);

            config.NewConfig<SocialEvent, CreateSocialEventResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.SubHeader, src => src.SubHeader)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Date, src => src.Date)
                .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
                .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime)
                .Map(dest => dest.Tags, src 
                    => src.Tags
                        .Select(tags =>
                                tags
                            // new { TagId = tags., Name = tags.Name }
                        )
                        .ToList())
                .Map(dest => dest.SocialEventTypes, src 
                    => src.SocialEventTypes
                        .Select(events => events)
                        .ToList());

            config.NewConfig<Domain.Tag.Tag, TagResponse>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Id, src => src.Id.Value);
            
            config.NewConfig<SocialEventType, SocialEventTypeResponse>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.SubTypes, src => src.SubTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}