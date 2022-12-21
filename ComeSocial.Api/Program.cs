using ComeSocial.Application;
using ComeSocial.Application.Authentication;
using ComeSocial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
   
}
// Add services to the container.

var app = builder.Build();
{
    app.MapControllers();
    app.UseRouting();

    app.Run();
}


