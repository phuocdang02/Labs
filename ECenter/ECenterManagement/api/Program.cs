using api.Configuration;
using api.DbContexts;
using api.Models;
using api.Repositories;
using api.Services;
using api.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

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

#region Dependency Injection (Unit of Work, Services, etc.)
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<FakeDataService>(); // Registered Bogus(Fake data generator)

services.AddScoped<IRepository<Teacher>, TeacherRepository>();
services.AddScoped<IRepository<Schedule>, ScheduleRepository>();
services.AddScoped<ITeacherService, TeacherService>();
services.AddScoped<IScheduleService, ScheduleService>();
#endregion

// Controllers and Endpoints
services.AddControllers();

// Add Identity
services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ECenterDbContext>()
    .AddDefaultTokenProviders();

// Configure JWT Authentication
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
services.AddAuthorization();
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

// Build Application
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
