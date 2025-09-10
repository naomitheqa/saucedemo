using saucedemo.saucedemoBase;
using saucedemo.saucedemoPages;
using saucedemo.saucedemoData;

namespace saucedemo.saucedemoTests;

public class LoginTests : TestBase
{
    protected SwagLabsInventoryPage SwagLabsInventoryPage;
    protected SwagLabsErrorMessages SwagLabsErrorMessages;
    private readonly String _password = "secret_sauce";

    [Test]
    public void TestBlankUsernameAndPassword()
    {
        SwagLabsHomePage.ClickLoginButton();
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.UsernameNotProvided));
    }

    [Test]
    public void TestBlankUsername()
    {
        SwagLabsHomePage.SetPassword(_password);
        SwagLabsHomePage.ClickLoginButton();
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.UsernameNotProvided));
    }
    
    [Test]
    public void TestBlankPassword()
    {
        SwagLabsHomePage.SetUsername("standard_user");
        SwagLabsHomePage.ClickLoginButton();
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.PasswordNotProvided));
    }
    
    [Test]
    public void TestStandardUserLogin()
    {
        SwagLabsInventoryPage = SwagLabsHomePage.LoginToSwagLabs("standard_user", _password);
        
        Assert.That(SwagLabsInventoryPage.IsInventoryPageDisplayed(), Is.True);
    }

    [Test]
    public void TestStandardUserLoginWithIncorrectPassword()
    {
        SwagLabsHomePage.LoginToSwagLabs("standard_user", "secret_waste");
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.InvalidCredentials));
    }

    [Test]
    public void TestNonExistentUserLoginAttempt()
    {
        SwagLabsHomePage.SetUsername("non_existent_user");
        SwagLabsHomePage.SetPassword(_password);
        SwagLabsHomePage.ClickLoginButton();
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.InvalidCredentials));
    }
    
    [Test]
    public void TestLockedOutUserLogin()
    {
        SwagLabsHomePage.SetUsername("locked_out_user");
        SwagLabsHomePage.SetPassword(_password);
        SwagLabsHomePage.ClickLoginButton();
        
        Assert.That(SwagLabsHomePage.GetErrorMessage(), Is.EqualTo(SwagLabsErrorMessages.LockedOutUser));
    }

    [Test]
    public void TestInvalidCredentialsErrorRecovery()
    {
        SwagLabsHomePage.SetUsername("standard_user");
        SwagLabsHomePage.SetPassword("_password");
        SwagLabsHomePage.ClickLoginButton();
        
        SwagLabsInventoryPage = SwagLabsHomePage.LoginToSwagLabs("standard_user", _password);

        Assert.That(SwagLabsInventoryPage.IsInventoryPageDisplayed(), Is.True);
    }
}