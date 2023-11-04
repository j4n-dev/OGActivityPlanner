using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OGActivityPlannerAPI.Configuration;
using OGActivityPlannerAPI.Entities.Security;
using OGActivityPlannerAPI.Services;
using OGActivityPlannerAPI.Services.Interfaces;
using OGActivityPlannerAPI.StaticData;
using System;
using System.Globalization;
using System.Text;

namespace OGActivityPlannerAPI
{
    /// <summary> The entry point class for the application. </summary>
    public class Program
    {
        /// <summary> The main entry point of the application. </summary>
        /// <param name="args"> Command-line arguments. </param>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency Injection
            builder.Services.AddTransient<IDbManagement, DbManagement>();
            builder.Services.AddScoped<IUserManagement, UserManagement>();
            builder.Services.AddScoped<IRoleManagement, RoleManagement>();

            // Configure JWT settings from appsettings.json
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            // Configure DefaultUser from appsettings.json
            builder.Services.Configure<DefaultUser>(builder.Configuration.GetSection("DefaultUser"));

            builder.Services.AddHttpClient();

            // Add localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Configure supported cultures
            var supportedCultures = new[]
            {
                new CultureInfo("de-DE"),
                new CultureInfo("en-US")
            };

            // Configure request localization
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("de-DE");
                options.SupportedCultures = supportedCultures;
            });

            // Get the connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Configure and add the database context
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            builder.Services.AddDbContext<OGAPContext>(dbContextOptions => dbContextOptions.UseMySql(
                connectionString,
                serverVersion,
                mySqlOptions => mySqlOptions.EnableRetryOnFailure()
            ).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors());

            // Configure Identity and authentication
            builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<OGAPContext>().AddDefaultTokenProviders();

            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key ?? ""))
                };
            });

            // Configure the JWT options
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

            // Configure Identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Seed default roles and users
            using (var scope = app.Services.CreateScope())
            {
                IDbManagement dbManagement = scope.ServiceProvider.GetRequiredService<IDbManagement>();
                await dbManagement.CheckDatabase();
            }

            app.Run();
        }
    }
}
