using ComeSocial.Domain.Common.Models;

namespace ComeSocial.Domain.ChatMessage.ValueObjects;

public class ChatMessageId : ValueObject
{
    public Guid Value { get; }

    private ChatMessageId(Guid value)
    {
        Value = value;
    }

    public static ChatMessageId CreateUnique() => new(Guid.NewGuid());

    public static ChatMessageId Create(Guid value) => new ChatMessageId(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return  Value;
    }
    private ChatMessageId() { }
}