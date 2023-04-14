using MediatR;

namespace ComeSocial.Application.ChatMessage.Commands.SendMessage;

public record SendMessageCommand(
    string Sender,
    string GroupId,
    string Content,
    DateTime SentOn
    ): IRequest<Domain.ChatMessage.ChatMessage>;