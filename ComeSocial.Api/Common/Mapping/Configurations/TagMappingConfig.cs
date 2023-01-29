using ComeSocial.Application.Contracts.SocialEvent;
using ComeSocial.Application.Contracts.Tag;
using ComeSocial.Application.Tag.Commands;
using ComeSocial.Domain.Tag;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTagRequest, CreateTagCommand>()
            .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<Tag, CreateTagResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);

        config.NewConfig<Tag, SocialEventTagResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}