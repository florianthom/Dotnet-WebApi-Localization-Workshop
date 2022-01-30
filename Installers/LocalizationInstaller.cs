using Microsoft.AspNetCore.Localization;

namespace hello_asp_localization.Installers;

public static class LocalizationInstaller
{

    public static void InstallLocalization(this IServiceCollection services)
    {

        services.AddLocalization(options =>
        {
            // not needed since specified in AssemblyInfo.cs
            // specified there since here assemblyName != rootNamespace and thats currently the
            // only way to solve it
            // options.ResourcesPath = "Resources";
        });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(
                culture: Settings.Localization.DefaultCulture,
                uiCulture: Settings.Localization.DefaultCulture
            );

            options.SupportedCultures = Settings.Localization.SupportedCultures;
            options.SupportedUICultures = Settings.Localization.SupportedCultures;
            options.FallBackToParentCultures = true;
            options.FallBackToParentUICultures = true;
            options.ApplyCurrentCultureToResponseHeaders = true;

            options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(context =>
            {
                var userLangs = context.Request.Headers["Accept-Language"].ToString();
                var firstLang = userLangs.Split(',').FirstOrDefault();
                var defaultLang = string.IsNullOrEmpty(firstLang) ? Settings.Localization.DefaultCulture : firstLang;
                return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang))!;
            }));
        });

    }
}