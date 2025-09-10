using saucedemo.saucedemoBase;
using saucedemo.saucedemoPages;

namespace saucedemo.saucedemoTests;

public class LoginTests : TestBase
{
    protected SwagLabsInventoryPage SwagLabsInventoryPage;
    [Test]
    public void testStandardUserLogin()
    {
        SwagLabsInventoryPage = SwagLabsHomePage.LoginToSwagLabs("standard_user", "secret_sauce");
        Assert.That(SwagLabsInventoryPage.IsInventoryPageDisplayed(), Is.True);
    }
}