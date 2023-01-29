using ComeSocial.Api;
using ComeSocial.Application;
using ComeSocial.Infrastructure;

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
    
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    
    app.Run();
}