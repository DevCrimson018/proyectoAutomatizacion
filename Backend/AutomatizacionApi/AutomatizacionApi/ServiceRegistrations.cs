using AutomatizacionApi.Application.Interfaces.Repositories;
using AutomatizacionApi.Application.Interfaces.Services;
using AutomatizacionApi.Application.Services;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Persistence.Context.Identity;
using AutomatizacionApi.Persistence.Context.Interceptors;
using AutomatizacionApi.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomatizacionApi
{
    public static class ServiceRegistrations
    {

        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //Initialize interceptor
            services.AddSingleton<AuditableEntityInterceptor>();
            //replace the connection string with the values from the configuration
            string identityConnection = configuration.GetConnectionString("IdentityConnection")!
                .Replace("${DB_HOST}", configuration["DB_HOST"])
                .Replace("${DB_NAME}", configuration["DB_NAME"])
                .Replace("${DB_USERNAME}", configuration["DB_USERNAME"])
                .Replace("${DB_PASSWORD}", configuration["DB_PASSWORD"]);

            // Add the identity context
            services.AddDbContext<IdentityContext>((sp, options) =>
            {
                var auditableInterceptor = sp.GetRequiredService<AuditableEntityInterceptor>();
                options.UseSqlServer(identityConnection,
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName))
                .AddInterceptors(auditableInterceptor);
            });

            // Add the identity services
            services.AddIdentity<ApplicationUser, ApplicationRole>()
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
            services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>))
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IBusRepository, BusRepository>()
            .AddTransient<IBusStatusRepository, BusStatusRepository>()
            .AddTransient<ILocationRepository, LocationRepository>()
            .AddTransient<ITicketRepository, TicketRepository>()
            .AddTransient<ITicketsCodeRepository, TicketsCodeRepository>()
            .AddTransient<IReservationRepository, ReservationRepository>()
            ;

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>()
                .AddTransient<IBusService, BusService>()
                .AddTransient<ILocationService, LocationService>()
                .AddTransient<ITicketService, TicketService>()
                .AddTransient<IReservationService, ReservationService>()
                .AddTransient<ITicketCodeService, TicketCodeService>()
                .AddTransient<IBusStatusServices, BusStatusServices>();
        }

    }
}
