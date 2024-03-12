using TestProject.Settings;

namespace TestProject.Tests;
public class TestBase
{
    public AppSettings _appSettings;

    [SetUp]
    public void BaseSetUp()
    {
        _appSettings = Settings.Settings.GetAppSettings();
    }
}