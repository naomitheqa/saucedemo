using OpenQA.Selenium;
using saucedemo.saucedemoBase;

namespace saucedemo.saucedemoPages;

public class SwagLabsInventoryPage : PageBase
{
    private By _inventoryPage = By.CssSelector("div[data-test='secondary-header']");

    public Boolean IsInventoryPageDisplayed()
    {
        return FindElement(_inventoryPage).Displayed;
    }
}