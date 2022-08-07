
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureCorsPolicy();

builder.Services.ConfigureDependency();


builder.Services.ConfigureLogging();

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.ConfigureAuthorization();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureCookie();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("EnableCORS");

app.Run();
