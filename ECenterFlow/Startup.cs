using ECenterFlow.Configuration;
using ECenterFlow.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ECenterFlow
{
    /// <summary>
    /// Represents the startup configuration for the application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructors
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration for the application
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        /// <param name="services">The collection of services to be configured</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
                options.RequestHeaders.Add("Cache-Control");
                options.ResponseHeaders.Add("Server");
            });

            #region IIS Express
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            #endregion

            #region Connection to MySQL
            string mySqlConnectionStr = Configuration.GetConnectionString("ECenterFlowConnection")!;
            services.AddDbContext<ECenterFlowDbContext>(
                optionsAction => optionsAction.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            #endregion

            #region Scope
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ECenterFlow Swagger UI",
                    Description = "ECenterFlow Swagger UI...",
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
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
                }});
            });
            #endregion

            #region CORS
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-total-count");
            }));
            #endregion
        }

        /// <summary>
        /// Configures the application's request processing pipeline.
        /// </summary>
        /// <param name="app">The application builder</param>
        /// <param name="environment">The hosting environment for the application</param>
        /// <param name="loggerFactory">The logger factory for configuring application logging</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment, ILoggerFactory loggerFactory)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Log", "ECenterFlow_API.log");
            loggerFactory.AddFile(path);

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECenter Flow Swagger API version 1.0"));
            }

            //app.UseHttpsRedirection();

            app.UseCors();

            // app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            if (!environment.IsDevelopment())
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers().RequireAuthorization();
                });
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
