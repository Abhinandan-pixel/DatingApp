using API.Data;
using API.interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;

namespace API.extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection")); //adds sqlite database to the service container
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}