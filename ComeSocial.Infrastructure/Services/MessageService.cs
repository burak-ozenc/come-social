using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Application.Contracts.Message;
using ComeSocial.Domain.ChatMessage;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ComeSocial.Infrastructure.Services;

public class MessageService : Hub, IMessageService
{
    private readonly ISender _mediator;

    public MessageService(ISender mediatr)
    {
        _mediator = mediatr;
    }
    
    public async Task<ChatMessageRequest> SendMessage(ChatMessage chatMessage)
    {
        await Task.CompletedTask;
        try
        {
            await Clients.All.SendAsync("ReceiveMessage", new
            {
                from = chatMessage.SenderId.Value,
                to = chatMessage.GroupId.Value,
                message = chatMessage.Content,
                createdOn = chatMessage.SentOn
            });

            // TODO
            // add to rabbit MQ queue
            // and persist to MongoDB
            
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void SendMQMessage(string from, string to, string message, string sentOn)
    {
        Clients.All.SendAsync("ReceiveMQMessage", new
        {
            from,
            to,
            message,
            createdOn = DateTime.Parse(sentOn)
        });
    }
}