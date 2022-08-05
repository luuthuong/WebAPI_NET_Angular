using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class ExtensionServices
    {
        public static void ConfigureCorsPolicy(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyOrigin()
                          .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureIISItergration(this IServiceCollection services)
        {

        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {

        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserModel,IdentityRole>()
                    .AddEntityFrameworkStores<IdentityUserContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(config =>
            {
                config.Password.RequireDigit = true;
            });
        }

        public static void ConfigureDbContext(this IServiceCollection services , IConfiguration config)
        {
            services.AddDbContext<IdentityUserContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("connection"));
            });

            services.AddDbContext<RepositoryContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("connection"));
            });
        }

        public static void ConfigureDependency(this IServiceCollection services)
        {
            //services.RegisterAssemblyPublicNonGenericClasses
        }

        public static void ConfigureLogging(this IServiceCollection services)
        {

        }

        public static void ConfigureCookie(this IServiceCollection services)
        {

        }
    }
}
