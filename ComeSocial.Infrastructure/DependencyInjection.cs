using System.Text;
using ComeSocial.Application.Common.Interfaces.Authentication;
using ComeSocial.Application.Common.Interfaces.Persistence;
using ComeSocial.Application.Common.Interfaces.Services;
using ComeSocial.Domain.Common.Authentication;
using ComeSocial.Infrastructure.Authentication;
using ComeSocial.Infrastructure.Persistence;
using ComeSocial.Infrastructure.Persistence.Configurations.IdentityConfigurations;
using ComeSocial.Infrastructure.Persistence.Repositories;
using ComeSocial.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ComeSocial.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddPersistence(configuration);
        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<ComeSocialDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                dbOptions => dbOptions.EnableRetryOnFailure()));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISocialEventRepository, SocialEventRepository>();
        services.AddScoped<IComeEventTypeRepository, ComeEventTypeRepository>();
        services.AddScoped<IInterestRepository, InterestRepository>();
        services.AddScoped<IUserService, UserService>();


        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        

        services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
            .AddEntityFrameworkStores<ComeSocialDbContext>();

        services.Configure<IdentityOptions>(options => ConfigureIdentityOptions(options));

        
        services.AddAuthentication(i =>
        {
            i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            i.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            i.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => ConfigureJwt(options, jwtSettings));

        return services;
    }

    private static void ConfigureIdentityOptions(IdentityOptions options)
    {
        // Password settings.
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 3;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50);
        options.Lockout.MaxFailedAccessAttempts = 50;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = true;
    }

    private static void ConfigureJwt(JwtBearerOptions options, JwtSettings jwtSettings)
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    }
}