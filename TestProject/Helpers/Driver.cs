using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Settings;

namespace TestProject.Helpers;

public class Driver
{
    private readonly IWebDriver _webDriver;

    public IWebDriver WebDriver { get { return _webDriver; } }

    public Driver(AppSettings appSettings)
    {
        _webDriver = StartSession(appSettings);
    }

    public IWebDriver StartSession(AppSettings appSettings)
    {
        IWebDriver webDriver;

        switch (appSettings.Browser)
        {
            case "Chrome":
                webDriver = ChromeBrowser(appSettings.Options);
                break;
            default:
                webDriver = ChromeBrowser(appSettings.Options);
                break;
        }

        return webDriver;
    }

    private static ChromeDriver ChromeBrowser(Options options)
    {
        var chromeOptions = new ChromeOptions();
        if (options.Headless)
        {
            chromeOptions.AddArgument("--headless=new");
        }
        return new ChromeDriver(chromeOptions);
    }

    public void EndSession()
    {
        if (_webDriver != null)
        {
            _webDriver.Quit();
        }
    }
}
