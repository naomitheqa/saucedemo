using OpenQA.Selenium;

namespace saucedemo.saucedemoBase;

public class PageBase
{
    public static IWebDriver Driver;

    public void SetDriver(IWebDriver driver)
    {
        PageBase.Driver = driver;
    }
    
    //DOC: Find element using provided locator
    protected IWebElement FindElement(By locator)
    {
        return Driver.FindElement(locator);
    }

    // DOC: Enter provided value in selected field
    protected void Set(By locator, string text)
    {
        FindElement(locator).Clear();
        FindElement(locator).SendKeys(text);
    }
    
    // DOC: Clicked on element provided by locator
    protected void ClickOn(By locator)
    {
        FindElement(locator).Click();
    }
}