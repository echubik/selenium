using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestProject.Pages;

public class DynamicPage : IPage
{
    private readonly string _path = "/selenium/web/dynamic.html";

    public string Path => _path;

    private IWebDriver _driver;

    public DynamicPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private By _btnReveal = By.Id("reveal");
    private By _txtRevealed = By.Id("revealed");

    public IWebElement BtnReveal
    {
        get { return _driver.FindElement(_btnReveal); }
    }

    public IWebElement TxtRevealed
    {
        get { return _driver.FindElement(_txtRevealed); }
    }

    public void ClickBtnReveal()
    {
        BtnReveal.Click();
    }

    public void SetTxtRevealed(string text)
    {
        TxtRevealed.SendKeys(text);
    }
    public string GetTxtRevealed()
    {
        return TxtRevealed.GetAttribute("value");
    }
}
