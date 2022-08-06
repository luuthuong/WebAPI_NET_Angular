using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Interface;
using Services;
using Services.Interface;
using System.Text;

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

        public static void ConfigureAuthentication(this IServiceCollection services,IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:8081 , http://localhost:8082",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Keys").GetSection("JWTTokenKey").Value))
                };
            });
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
            services.AddSingleton<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
        }

        public static void ConfigureLogging(this IServiceCollection services)
        {

        }

        public static void ConfigureCookie(this IServiceCollection services)
        {

        }
    }
}
