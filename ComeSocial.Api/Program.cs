using ComeSocial.Api;
using ComeSocial.Api.Common.Errors;
using ComeSocial.Application;
using ComeSocial.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
    app.MapControllers();
    app.UseRouting();

    app.Run();
}


