using Backend.Business;
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

#region Collection_Service
service.ConfigureIISItergration(builder.Configuration);
service.ConfigureCorsPolicy();
service.ConfigureDbContext(builder.Configuration);
service.ConfigureIdentity();
service.ConfigureAuthentication(builder.Configuration);
service.ConfigureAuthorization();
service.DIServiceRegister();
service.ConfigureAutoMapper();
service.ConfigureMediatR();
#endregion

service.AddControllers();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var app = builder.Build();
//Handle required service
app.Services.HandleRequiredService();

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
