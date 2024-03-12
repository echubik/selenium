using Microsoft.Extensions.Configuration;

namespace TestProject.Settings;

public static class Settings
{
    public static AppSettings GetAppSettings()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, false)
            .Build();

        var appSettings = new AppSettings();
        configuration.Bind(appSettings, x => x.BindNonPublicProperties = true);

        return appSettings;
    }
}