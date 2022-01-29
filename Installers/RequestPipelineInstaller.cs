using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace hello_asp_localization.Installers;

public static class RequestPipelineInstaller
{
    public static void InstallRequestPipeline(this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("v1/swagger.json", "hello-asp-identity (V1)");
            });
        }
        app.UseHttpsRedirection();

        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>()!;

        // var supportedCultures = new[] { "en-US", "fr-FR" };
        // var localizationOptions = new RequestLocalizationOptions()
        //     .SetDefaultCulture(supportedCultures[0])
        //     .AddSupportedCultures(supportedCultures)
        //     .AddSupportedUICultures(supportedCultures);

        // app.UseRequestLocalization(localizationOptions);

        app.UseRequestLocalization(options.Value);

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}