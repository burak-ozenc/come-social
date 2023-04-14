using Microsoft.AspNetCore.SignalR;

namespace ComeSocial.Infrastructure.Providers;

public class CustomGroupIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identity?.Name;
    }
}