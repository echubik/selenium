using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Settings;

namespace TestProject.Infrastructure;

public class Driver
{
    private readonly IWebDriver _webDriver;

    public IWebDriver WebDriver => _webDriver;

    public Driver(AppSettings appSettings)
    {
        _webDriver = StartSession(appSettings);
    }

    public IWebDriver StartSession(AppSettings appSettings)
    {
        return appSettings.Browser switch
        {
            "Chrome" => ChromeBrowser(appSettings.BrowserOptions),
            _ => ChromeBrowser(appSettings.BrowserOptions),
        };
    }

    private static ChromeDriver ChromeBrowser(BrowserOptions browserOptions)
    {
        var chromeOptions = new ChromeOptions();
        if (browserOptions.Headless)
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
