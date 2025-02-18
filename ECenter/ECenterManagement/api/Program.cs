using api.Configuration;
using api.DbContexts;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Load Configuration
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add Services
var services = builder.Services;

services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    options.RequestHeaders.Add("Cache-Control");
    options.ResponseHeaders.Add("Server");
});

// IIS Express Configuration
services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// Connection to MySQL
string mySqlConnectionStr = builder.Configuration.GetConnectionString("ECenterFlowConnection")!;
services.AddDbContext<ECenterDbContext>(
    options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

// Dependency Injection (Unit of Work, Services, etc.)
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<FakeDataService>();

// Controllers and Endpoints
services.AddControllers();
services.AddEndpointsApiExplorer();

// CORS Policy
services.AddCors(o => o.AddPolicy("AllowAll", policyBuilder =>
{
    policyBuilder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithExposedHeaders("X-total-count");
}));

// Swagger Configuration
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ECenter Swagger UI",
        Description = "ECenter API Documentation"
    });

    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Build App
var app = builder.Build();

// Logging
string logPath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "ECenter_API.log");
var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
loggerFactory.AddFile(logPath);

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECenter API v1"));
}

app.UseCors("AllowAll");

app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
