using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;

namespace hello_asp_localization.Installers;

public static class SwaggerInstaller
{
    public static void InstallSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(a =>
        {
            a.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });

            var xmlFile = Assembly.GetExecutingAssembly().GetName().Name?.ToString() + ".xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            a.IncludeXmlComments(xmlPath);
        });
    }
}