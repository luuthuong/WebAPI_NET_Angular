using Common;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Repositories;
using Repositories.Interface;
using Services;
using Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Token;
using Token.Interface;

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

        public static void ConfigureIISItergration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = config["IIS:DisplayName"];
                iis.AutomaticAuthentication = false;
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services,IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = config["JWT:ValidIssuer"],
                    ValidAudience = config["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:JWTTokenKey"])),
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserModel,RoleModel>()
                    .AddRoles<RoleModel>()
                    .AddEntityFrameworkStores<IdentityUserContext>()
                    .AddDefaultTokenProviders();

            //services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseErrorEvents = true;
            //}).AddInMemoryIdentityResources();

            services.Configure<IdentityOptions>(config =>
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
            //Dependency Authentication
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();

            //DependencyRepository
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();

            //Dependency Services DbContext
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleServices,RoleServices>();

            //Dependency Token service
            services.AddScoped<ITokenService, TokenServices>();

            //Dependency claimTransformationIdentity
            services.AddTransient<IClaimsTransformation, ClaimTransformationIdentity>();

        }

        public static void ConfigureLogging(this IServiceCollection services)
        {

        }

        public static void ConfigureCookie(this IServiceCollection services)
        {

        }
    }
}
