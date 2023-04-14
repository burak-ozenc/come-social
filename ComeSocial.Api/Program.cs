using ComeSocial.Api;
using ComeSocial.Application;
using ComeSocial.Infrastructure;
using ComeSocial.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

// Add services to the container.
var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    
    // TODO
    // add automated migrations
    
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    
    // custom provider
    app.MapHub<MessageService>("/messageHub");
    app.AddMessageProvider();

    app.Run();
}