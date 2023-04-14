using ComeSocial.Application.ChatMessage.Commands.SendMessage;
using ComeSocial.Application.Contracts.Message;
using ComeSocial.Domain.ChatMessage;
using ComeSocial.Domain.Group.ValueObjects;
using ComeSocial.Domain.User.ValueObjects;
using Mapster;

namespace ComeSocial.Api.Common.Mapping.Configurations;

public class ChatMessageMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ChatMessageRequest, SendMessageCommand>()
            .Map(dest => dest.Sender, src => src.From)
            .Map(dest => dest.GroupId, src => src.To)
            .Map(dest => dest.Content, src => src.Message)
            .Map(dest => dest.SentOn, src => src.SentOn);

        config.NewConfig<SendMessageCommand, ChatMessage>()
            .Map(dest => dest.SenderId, src => src.Sender)
            .Map(dest => dest.GroupId, src => src.GroupId)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.SentOn, src => src.SentOn);

        config.NewConfig<GroupId, string>()
            .Map(dest => dest, src => src.Value);
        config.NewConfig<UserId, string>()
            .Map(dest => dest, src => src.Value);
        
        // throw new NotImplementedException();
    }
}