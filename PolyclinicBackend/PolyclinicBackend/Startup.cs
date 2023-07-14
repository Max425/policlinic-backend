using Data.DAL.Context;
using Microsoft.OpenApi.Models;
using Data.DAL.Repositories;
using Data.BLL.Service;
using Data.BLL.Facade;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Data.BLL.Services;

namespace PolyclinicBackend;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void CoufigureAuth(IEndpointRouteBuilder app, CredentialService credentialService) 
    {
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("Polyclinic", new OpenApiInfo
            {
                Title = "Polyclinic",
                Version = "v2"
            });
            c.SwaggerDoc("Admin", new OpenApiInfo
            {
                Title = "Admin",
                Version = "v2"
            });
            c.SwaggerDoc("Login", new OpenApiInfo
            {
                Title = "Login",
                Version = "v2"
            });
        });

        services.AddDbContext<PolyclinicContext>();
        services.AddDbContext<GeneratedContext>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidateAudience = true,
                ValidAudience = AuthOptions.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        });

        services.AddControllersWithViews();

        services.AddTransient<VisitorRepository>();
        services.AddTransient<RecordRepository>();
        services.AddTransient<SurveyRepository>();
        services.AddTransient<DoctorRepository>();
        services.AddTransient<CredentialsRepository>();
        services.AddTransient<OperatorRepository>();
        services.AddTransient<VisitorGeneratedRepository>();

        services.AddTransient<CredentialService>();
        services.AddTransient<DoctorService>();
        services.AddTransient<OperatorService>();
        services.AddTransient<RecordService>();
        services.AddTransient<VisitorService>();
        services.AddTransient<SurveyService>();
        //services.AddHostedService<BackgroundWorkerService>();

        services.AddTransient<Facade>();

        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddAuthentication();
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/Polyclinic/swagger.json", "Polyclinic");
            c.SwaggerEndpoint("/swagger/Admin/swagger.json", "Admin");
            c.SwaggerEndpoint("/swagger/Login/swagger.json", "Login");
        });
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
        });

    }
}
