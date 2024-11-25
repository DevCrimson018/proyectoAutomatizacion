using AutomatizacionApi.Context.Identity;
using AutomatizacionApi.Entities;
using AutomatizacionApi.Interfaces.Repositories;
using AutomatizacionApi.Interfaces.Services;
using AutomatizacionApi.Repositories;
using AutomatizacionApi.SEEDs;
using AutomatizacionApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi
{
    public static class ServiceRegistrations
    {

        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //replace the connection string with the values from the configuration
            string identityConnection = configuration.GetConnectionString("IdentityConnection")!
                .Replace("${DB_HOST}", configuration["DB_HOST"])
                .Replace("${DB_NAME}", configuration["DB_NAME"])
                .Replace("${DB_USERNAME}", configuration["DB_USERNAME"])
                .Replace("${DB_PASSWORD}", configuration["DB_PASSWORD"]);

            // Add the identity context
            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(identityConnection,
            m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            // Add the identity services
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // Configure the lockout settings
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

    }
}
