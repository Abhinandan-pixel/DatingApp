using API.extensions;

var builder = WebApplication.CreateBuilder(args); //creates webapp instance

// Add services to the container.
builder.Services.AddControllers(); //adds controllers to the service container
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration); //adds identity services to the service container

var app = builder.Build();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //allows any header and method from the specified origin

app.UseAuthentication(); //adds authentication middleware to the pipeline
app.UseAuthorization(); //adds authorization middleware to the pipeline

app.MapControllers(); //maps the controllers to the app

app.Run();

