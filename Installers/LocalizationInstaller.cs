using System.Globalization;
using hello_asp_localization.Domain;
using Microsoft.AspNetCore.Localization;

namespace hello_asp_localization.Installers;

public static class LocalizationInstaller
{
    public static string DefaultCulture { get; set; } = "en-US";
    public static List<CultureInfo> SupportedCultures { get; set; } = new()
    {
        new(DefaultCulture),
        new CultureInfo("en"),
        new CultureInfo("de-DE"),
        new CultureInfo("de-AT"),
        new CultureInfo("fr-FR"),
    };

    public static void InstallLocalization(this IServiceCollection services)
    {

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(culture: DefaultCulture, uiCulture: DefaultCulture);
            options.SupportedCultures = SupportedCultures;
            options.SupportedUICultures = SupportedCultures;
            options.FallBackToParentCultures = true;
            options.FallBackToParentUICultures = true;

            options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
            {
                var userLangs = context.Request.Headers["Accept-Language"].ToString();
                var firstLang = userLangs.Split(',').FirstOrDefault();
                var defaultLang = string.IsNullOrEmpty(firstLang) ? DefaultCulture : firstLang;
                return new ProviderCultureResult(defaultLang, defaultLang);
            }));
        });

    }
}