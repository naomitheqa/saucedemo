using OpenQA.Selenium;
using saucedemo.saucedemoBase;

namespace saucedemo.saucedemoPages;

public class SwagLabsHomePage : PageBase
{
  private By _usernameField = By.Id("user-name");
  private By _passwordField = By.Id("password");
  private By _loginButton = By.Id("login-button");
  private By _errorMessage = By.CssSelector("div[class^='error-message-container']");

  public void SetUsername(string username)
  {
    Set(_usernameField, username);
  }

  public void SetPassword(string password)
  {
    Set(_passwordField, password);
  }

  public String GetErrorMessage()
  {
    return FindElement(_errorMessage).Text;
  }

  public SwagLabsInventoryPage ClickLoginButton()
  {
    ClickOn(_loginButton);
    return new SwagLabsInventoryPage();
  }

  public SwagLabsInventoryPage LoginToSwagLabs(string username, string password)
  {
    SetUsername(username);
    SetPassword(password);
    return ClickLoginButton();
  }
}