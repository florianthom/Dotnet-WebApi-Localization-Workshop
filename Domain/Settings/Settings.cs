using System.Collections.ObjectModel;
using System.Globalization;

public static class Settings
{
    public static class Localization
    {
        public const string DefaultCulture = "en-US";
        // public const IReadOnlyList<CultureInfo> SupportedCultures = ReadOnlyCollection<CultureInfo>
        // {
        //     new CultureInfo(DefaultCulture),
        //     new CultureInfo("en"),
        //     new CultureInfo("de-DE"),
        //     new CultureInfo("de-AT"),
        //     new CultureInfo("fr-FR"),
        // };
        public static readonly IList<CultureInfo> SupportedCultures = new ReadOnlyCollection<CultureInfo>(new List<CultureInfo> {
            new CultureInfo(DefaultCulture),
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("de-AT"),
            new CultureInfo("fr-FR"),
        });
    }

    public static class ErrorCode { }

    public static class Permission
    {
        public const string PolicyPrefix = "Permission:";
        public const string PolicyNameSplitSymbol = ":";
        public const string PackingSymbol = ":";
    }

}