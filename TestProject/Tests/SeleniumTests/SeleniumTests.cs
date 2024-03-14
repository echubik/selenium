using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestProject.Infrastructure;
using TestProject.Pages;

namespace TestProject.Tests.SeleniumTests;

[TestFixture]
public class SeleniumTests : TestBase
{
    private Driver _driver;
    private StartPage _startPage;

    [SetUp]
    public void Setup()
    {
        _driver = new Driver(_appSettings);
        _startPage = new StartPage(_driver.WebDriver);

        _driver.WebDriver.Navigate().GoToUrl(_appSettings.Domain + _startPage.Path);
        _driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.EndSession();
    }

    [Test]
    public void ClickSubmitTest()
    {
        var newPage = _startPage.ClickButton();
        var message = newPage.GetMessage();

        Assert.That(message, Is.EqualTo("Received!"));
    }

    [TestCase("example")]
    public void SetTextTest(string text)
    {
        _startPage.SetMyText(text);

        Assert.That(text, Is.EqualTo(_startPage.GetMyText()));
    }

    [Test]
    public void SetTextByActionTest()
    {
        var action = new Actions(_driver.WebDriver);
        action.KeyDown(Keys.Shift)
              .SendKeys(_startPage.FindMyText(), "a")
              .Perform();

        Assert.That("A", Is.EqualTo(_startPage.GetMyText()));
    }

}
