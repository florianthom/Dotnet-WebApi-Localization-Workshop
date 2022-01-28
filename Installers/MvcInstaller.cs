namespace hello_asp_localization.Installers;

public static class MvcInstaller
{
    public static void InstallMvc(this IServiceCollection services)
    {
        services
            .AddControllers(options => { })
            .AddDataAnnotationsLocalization();
    }
}