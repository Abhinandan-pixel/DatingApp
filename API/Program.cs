using API.Data;
using API.extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); //creates webapp instance

// Add services to the container.
builder.Services.AddControllers(); //adds controllers to the service container
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration); //adds identity services to the service container

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //allows any header and method from the specified origin

app.UseAuthentication(); //adds authentication middleware to the pipeline
app.UseAuthorization(); //adds authorization middleware to the pipeline

app.MapControllers(); //maps the controllers to the app

using var scope = app.Services.CreateScope(); //This is going to give us access to the services in the container 
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync(); //migrates the database to the latest version
    await Seed.SeedUsers(context); //seeds the database with initial data
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();

