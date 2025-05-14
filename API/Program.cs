using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); //creates webapp instance

// Add services to the container.
builder.Services.AddControllers(); //adds controllers to the service container
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //adds sqlite database to the service container
});
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); //allows any header and method from the specified origin

app.MapControllers(); //maps the controllers to the app

app.Run();

