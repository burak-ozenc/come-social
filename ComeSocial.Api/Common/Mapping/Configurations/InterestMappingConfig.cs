using ComeSocial.Application.Contracts.Interest;
using ComeSocial.Application.Interest.Commands.CreateInterestCommand;
using ComeSocial.Domain.Interest;
using ComeSocial.Domain.Interest.ValueObjects;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class InterestMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateInterestRequest, CreateInterestCommand>()
            .Map(dest => dest.TagIds,
                src => src.TagIds.ConvertAll(tagId => tagId.Id));

        config.NewConfig<Interest, CreateInterestResponse>()
            .Map(dest => dest.Id, src => src.MessageId.Value)
            .Map(dest => dest.TagIds,
                src => src.Tags.Select(tagId => tagId.Value));

        config.NewConfig<InterestId, InterestTagResponse>()
            .Map(dest => dest.Id, src => src.Value);
    }
}