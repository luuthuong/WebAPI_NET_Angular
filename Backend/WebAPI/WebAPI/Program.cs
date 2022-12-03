using Backend.Common;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

var path = Directory.GetCurrentDirectory();
var environtmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
builder.Configuration.SetBasePath(path)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environtmentName}.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

SeriLogHelper.UseCustomizedSerilog(environtmentName, builder.Configuration);

service.ConfigureIISItergration(builder.Configuration);
service.ConfigureCorsPolicy();
service.ConfigureDbContext(builder.Configuration);
service.ConfigureIdentity();
service.ConfigureAuthentication(builder.Configuration);
service.ConfigureAuthorization();

// Add services to the container.

service.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
