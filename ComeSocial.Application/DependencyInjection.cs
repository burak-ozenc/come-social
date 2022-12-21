using ComeSocial.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ComeSocial.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
