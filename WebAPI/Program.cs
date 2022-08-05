
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureDependency();
builder.Services.ConfigureIISItergration();
builder.Services.ConfigureLogging();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureCookie();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
