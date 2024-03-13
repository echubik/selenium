using Microsoft.Extensions.Configuration;

namespace TestProject.Settings;

public static class Settings
{
    public static AppSettings GetAppSettings()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        var appSettings = new AppSettings();
        configuration.GetSection("AppSettings").Bind(appSettings);

        return appSettings;
    }
}