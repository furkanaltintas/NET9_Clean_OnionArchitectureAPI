using OnionDemo.Application.Exceptions;
using OnionDemo.Infrastructure;
using OnionDemo.Persistence;
using OnionDemo.Application;
using OnionDemo.Mapper;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();


var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "OnionDemo.Api", Version = "v1", Description = "OnionDemo Api swagger client." });
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "'Bearer' yazýp boþluk býrakarak token deðerini giriniz."
    });
    c.AddSecurityRequirement(new()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id  = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();