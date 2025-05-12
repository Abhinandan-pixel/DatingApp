using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); //creates webapp instance

// Add services to the container.
builder.Services.AddControllers(); //adds controllers to the service container
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); //adds sqlite database to the service container
});

var app = builder.Build();

app.MapControllers(); //maps the controllers to the app

app.Run();

