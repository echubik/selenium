using OpenQA.Selenium;

namespace TestProject.Pages;

public class SubmittedPage : IPage
{
    private readonly string _path = "/selenium/web/submitted-form.html";

    public string Path => _path;

    private IWebDriver _driver;

    public SubmittedPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By _message = By.Id("message");

    public string GetMessage()
    {
        var message = _driver.FindElement(_message);
        return message.Text;
    }
}
