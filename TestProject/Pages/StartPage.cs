using OpenQA.Selenium;

namespace TestProject.Pages;

public class StartPage : IPage
{
    private readonly string _path = "/selenium/web/web-form.html";

    public string Path
    {
        get { return _path; }
    }

    private IWebDriver _driver;

    public StartPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By _btnSubmit = By.TagName("button");

    public SubmittedPage ClickButton()
    {
        var submitButton = _driver.FindElement(_btnSubmit);
        submitButton.Click();

        return new SubmittedPage(_driver);
    }
}
