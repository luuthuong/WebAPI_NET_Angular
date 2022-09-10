using Common;
using Common.Interface;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NLog;
using Repositories;
using Repositories.Blog;
using Repositories.Interface;
using Repositories.Interface.Blog;
using Repositories.Interface.Media;
using Repositories.Media;
using Services;
using Services.Blog;
using Services.Interface;
using Services.Interface.Blog;
using Services.Interface.Media;
using Services.Media;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
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
                options.AddPolicy("EnableCORS", policy =>
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

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = long.MaxValue;
                options.MaxRequestBodyBufferSize = int.MaxValue;
                
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue; // if don't set default value is: 30 MB
                options.Limits.MaxRequestBufferSize = long.MaxValue;
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueCountLimit =int.MaxValue;
                x.BufferBodyLengthLimit = long.MaxValue;
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = long.MaxValue; // if don't set default value is: 128 MB
                x.MultipartHeadersLengthLimit = int.MaxValue;
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
                    ValidateIssuer = true,
                    ValidateAudience = true,
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
            //service.AddAuthorization(options =>
            //{
            //    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
            //    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
            //    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            //});
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
        }

        public static void ConfigureDependency(this IServiceCollection services)
        {
            //Dependency Authentication
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            //Dependency Token service
            services.AddScoped<ITokenService, TokenServices>();

            //DependencyRepository
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
            services.AddScoped<IFileMediaRepository, FileMediaRepository>();
            services.AddScoped<IMediaCategoryRepository, MediaCategoryRepository>();
            services.AddScoped<IFileCategoryRepository, FileCategoryRepository>();
            //Blog
            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IPostMetaRepository, PostMetaRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostTagRepository, PostTagRepository>();
            services.AddScoped<ITagRepository, TagRepository>();


            //Dependency Services DbContext
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleServices,RoleServices>();
            services.AddScoped<IFileMediaServices, FileMediaServices>();
            services.AddScoped<IMediaCategoryServices,MediaCategoryServices>();

            services.AddScoped<IPostService, PostService>();
            

            //Dependency claimTransformationIdentity
            services.AddTransient<IClaimsTransformation, ClaimTransformationIdentity>();


        }

        public static void ConfigureLogging(this IServiceCollection services)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "./nlog.config"));
            services.AddSingleton<ILoggerManager,LoggerManager>();
        }

        public static void ConfigureCookie(this IServiceCollection services)
        {

        }
    }
}
