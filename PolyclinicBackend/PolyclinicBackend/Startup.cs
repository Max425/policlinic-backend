﻿using Data.DAL.Context;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data.DAL.Repositories;
using Data.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Data.BLL.Service;
using Data.BLL.DTO;
using Data.DAL;
using Data.BLL.Facade;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.AspNetCore.Authentication;

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
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Here Enter JWT Token with bearer format like bearer[space] token"
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
                       }
                   },
                   new string[]{}
                }
            });
        });

        services.AddDbContext<PolyclinicContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataConnection")));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
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

        services.AddTransient<CredentialService>();
        services.AddTransient<DoctorService>();
        services.AddTransient<OperatorService>();
        services.AddTransient<RecordService>();
        services.AddTransient<VisitorService>();
        services.AddTransient<SurveyService>();

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
