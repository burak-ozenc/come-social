using ComeSocial.Application.Contracts.Message;

namespace ComeSocial.Application.Common.Interfaces.Services;

public interface IMessageService
{
    Task<ChatMessageRequest> SendMessage(Domain.ChatMessage.ChatMessage chatMessage);
}