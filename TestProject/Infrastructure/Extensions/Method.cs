using OpenQA.Selenium;

namespace TestProject.Infrastructure.Extensions;

public static class ExtensionMethod
{
    public static bool IsElementPresent(this IWebDriver webDriver, By element)
    {
        try
        {
            webDriver.FindElement(element);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
