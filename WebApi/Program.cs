using Logging;
using Scalar.AspNetCore;
using Serilog;
using WebApi.Common;
using WebApi.Extensions;
using WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLayers(builder.Configuration);

builder.Host.UseSerilog(Logger.ConfigureLogger);

builder.Services.AddScoped<IMapper, Mapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}


app.MapPrometheusScrapingEndpoint();

app.UseCustomExceptions();

app.ApplyMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
