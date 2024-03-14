using OpenQA.Selenium;

namespace TestProject.Pages;

public class StartPage : IPage
{
    private readonly string _path = "/selenium/web/web-form.html";

    public string Path => _path;

    private IWebDriver _driver;

    public StartPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By _btnSubmit = By.TagName("button");
    private By _myText = By.Id("my-text-id");

    public SubmittedPage ClickButton()
    {
        var submitButton = _driver.FindElement(_btnSubmit);
        submitButton.Click();

        return new SubmittedPage(_driver);
    }

    public void SetMyText(string text)
    {
        _driver.FindElement(_myText).SendKeys(text);
    }
    public string GetMyText()
    {
        return _driver.FindElement(_myText).GetAttribute("value");
    }
    public IWebElement FindMyText()
    {
        return _driver.FindElement(_myText);
    }
}
