using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject.Infrastructure;
using TestProject.Pages;

namespace TestProject.Tests.SeleniumTests;

[TestFixture]
public class DynamicPageTests : TestBase
{
    private Driver _driver;
    private DynamicPage _dynamicPage;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        _driver = new Driver(_appSettings);
        _dynamicPage = new DynamicPage(_driver.WebDriver);
        _wait = new WebDriverWait(_driver.WebDriver, TimeSpan.FromSeconds(2));

        _driver.WebDriver.Navigate().GoToUrl(_appSettings.Domain + _dynamicPage.Path);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.EndSession();
    }

    [TestCase("example")]
    public void ExplicitTest(string text)
    {
        _dynamicPage.ClickBtnReveal();

        _wait.Until(_ => _dynamicPage.TxtRevealed.Displayed);

        _dynamicPage.SetTxtRevealed(text);

        Assert.That(text, Is.EqualTo(_dynamicPage.GetTxtRevealed()));
    }
}
