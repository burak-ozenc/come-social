using ComeSocial.Application.ComeEventType.Commands.CreateComeEventType;
using ComeSocial.Application.Contracts.ComeEventType;
using ComeSocial.Domain.ComeEventType;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class ComeEventTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateComeEventTypeRequest, CreateComeEventTypeCommand>()
            .Map(dest => dest.Name, src => src.Name);
        
        config.NewConfig<ComeEventType, CreateComeEventTypeResponse>()
            .Map(dest => dest.Id, src => src.MessageId.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);

        config.NewConfig<ComeEventType, CreateComeEventTypeResponse>()
            .Map(dest => dest.Id, src => src.MessageId.Value);


    }
}