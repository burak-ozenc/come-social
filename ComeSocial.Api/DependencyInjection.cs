using ComeSocial.Api.Common.Errors;
using ComeSocial.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ComeSocial.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, ComeSocialProblemDetailsFactory>();
        return services;
    }
}