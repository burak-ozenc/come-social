namespace ComeSocial.Application.Contracts.Message;

public record ChatMessageRequest(
    string From, 
    string To,
    string Message,
    string SentOn);