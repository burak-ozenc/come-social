using ComeSocial.Domain.ChatMessage.ValueObjects;
using ComeSocial.Domain.Common.Models;
using ComeSocial.Domain.Group.ValueObjects;
using ComeSocial.Domain.User.ValueObjects;

namespace ComeSocial.Domain.ChatMessage;

public sealed class ChatMessage : AggregateRoot<ChatMessageId>
{
    public UserId SenderId { get; private set; }
    public GroupId GroupId { get; private set; }
    public string Content { get; private set; }
    public DateTime? SentOn { get; private set; }

    private ChatMessage(ChatMessageId messageId,
        UserId senderId,
        GroupId groupId, 
        string content, 
        DateTime? sentOn) : base (messageId)
    {
        GroupId = groupId;
        Content = content;
        SentOn = sentOn;
        SenderId = senderId;
    }

    public static ChatMessage Create(
        UserId senderId,
        GroupId groupId,
        string content,
        DateTime? sentOn
    ) => new(ChatMessageId.CreateUnique(),
        senderId, 
        groupId,
        content,
        sentOn);
    
    private ChatMessage(){}
}