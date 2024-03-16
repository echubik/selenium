using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestProject.Infrastructure;
using TestProject.Pages;

namespace TestProject.Tests.SeleniumTests;

[TestFixture]
public class StartPageTests : TestBase
{
    private Driver _driver;
    private StartPage _startPage;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        _driver = new Driver(_appSettings);
        _startPage = new StartPage(_driver.WebDriver);
        _wait = new WebDriverWait(_driver.WebDriver, TimeSpan.FromSeconds(2));

        _driver.WebDriver.Navigate().GoToUrl(_appSettings.Domain + _startPage.Path);
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
              .SendKeys(_startPage.MyText, "a")
              .Perform();

        Assert.That("A", Is.EqualTo(_startPage.GetMyText()));
    }

}
