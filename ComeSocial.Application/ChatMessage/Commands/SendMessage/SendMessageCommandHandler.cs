using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Group.ValueObjects;
using ComeSocial.Domain.User.ValueObjects;
using MediatR;

namespace ComeSocial.Application.ChatMessage.Commands.SendMessage;

internal sealed class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Domain.ChatMessage.ChatMessage>
{
    private readonly IMessageService _messageService;

    public SendMessageCommandHandler(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async Task<Domain.ChatMessage.ChatMessage> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var message = Domain.ChatMessage.ChatMessage.Create(
            senderId: UserId.Create(Guid.Parse(request.Sender)) , 
            groupId: GroupId.Create(Guid.Parse(request.GroupId)),
            content: request.Content,
            sentOn: request.SentOn);
        
        await _messageService.SendMessage(message);
        
        // TODO
        // add to rabbitMQ queue
        // rabbitMQ will handle persistence

        throw new NotImplementedException();
    }
}