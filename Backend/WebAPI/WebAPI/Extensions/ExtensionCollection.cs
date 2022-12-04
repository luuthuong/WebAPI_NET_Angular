using Backend.DBContext;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using AutoMapper;
using System.Text;
using Backend.Common;
using Backend.Business;

namespace WebAPI.Extensions
{
    public static class ExtensionCollection
    {
        public static void ConfigureCorsPolicy(this IServiceCollection service)
        {
            service.AddCors(option =>
            {
                option.AddPolicy("EnableCORS", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                    //policy.AllowCredentials();
                });
            });
        }

        public static void ConfigureIISItergration(this IServiceCollection service, IConfiguration configuration)
        {
            var txt = configuration["IIS:DisplayName"];
            service.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = configuration["IIS:DisplayName"];
                iis.AutomaticAuthentication = false;
            });

            service.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = long.MaxValue;
                options.MaxRequestBodyBufferSize = int.MaxValue;

            });
            service.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue; // if don't set default value is: 30 MB
                options.Limits.MaxRequestBufferSize = long.MaxValue;
            });

            service.Configure<FormOptions>(x =>
            {
                x.ValueCountLimit = int.MaxValue;
                x.BufferBodyLengthLimit = long.MaxValue;
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue; // if don't set default value is: 128 MB
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });
        }

        public static void ConfigureDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void HandleRequiredService(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                Log.Information("Starting migration");
                var dbContext = provider.GetRequiredService<AppDbContext>();
                var connectionString = dbContext.Database.GetConnectionString();
                Log.Information($"============= Connection string: {connectionString}");
                dbContext.Database.Migrate();
                DataSeedingContext.InitSeedDataMigrationAsync(dbContext, provider).Wait();
            }
        }

        public static void ConfigureIdentity(this IServiceCollection service)
        {
            service.AddIdentity<User, Role>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequireUppercase = false;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequiredLength = 1;
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection service)
        {
            service.AddAuthorization(option =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                option.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidAudience = configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:JWTTokenKey"])),
                };
            });
        }

        public static void ConfigureAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(Utilities.GetAssembliesOfType(typeof(Profile), typeof(ServiceBase)));
        }
    }
}
