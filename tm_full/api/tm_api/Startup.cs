using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

using tm_api.Configuration;
using tm_api.Data;

namespace tm_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
                options.RequestHeaders.Add("Cache-Control");
                options.ResponseHeaders.Add("Server");
            });

            //ISS Express:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            #region Connection Strings
            string mySqlConnectionStr = Configuration.GetConnectionString("tm_connection")!;
            services.AddDbContext<EnglishCenterManagementDBContext>(
                options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //Authentication

            //Authorization

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "English Center Management API",
                    Description = "English Center Management App Backend API",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter Bearer [space] and then your token in the text input below.
                      Example: Bearer <token>",
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

            //Add CORS
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-total-count");
            }));
        }

        /// <summary>
        /// Configures the application's request processing pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="environment">The hosting environment for the application.</param>
        /// <param name="loggerFactory">The logger factory for configuring application logging.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment, ILoggerFactory loggerFactory)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Log", "ecm.log");
            loggerFactory.AddFile(path);

            //if (environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            //app.UseMiddleware<JwtMiddleware>();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMSC App Swagger API");
            //    c.RoutePrefix = string.Empty;
            //});
        }
    }
}
