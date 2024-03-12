using OpenQA.Selenium;

namespace TestProject.Pages;

public class StartPage
{
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
