using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using saucedemo.saucedemoPages;

namespace saucedemo.saucedemoBase;

public class TestBase
{
    protected WebDriver Driver;
    protected PageBase PageBase;
    protected SwagLabsHomePage SwagLabsHomePage;
    private readonly String _url = "https://www.saucedemo.com/";

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(_url);
        PageBase = new PageBase();
        PageBase.SetDriver(Driver);
        SwagLabsHomePage = new SwagLabsHomePage();
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}