using OpenQA.Selenium;

namespace SeleniumTests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _driver.Navigate().GoToUrl("https://account.proton.me/login");
    }

    public void Login(string? email, string password)
    {
        var emailField = _driver.FindElement(By.Id("username"));

        emailField.Click();
        emailField.SendKeys(email);

        var passwordField = _driver.FindElement(By.Id("password"));

        passwordField.Click();
        passwordField.SendKeys(password);

        var submitButton =
            _driver.FindElement(By.CssSelector("button.button.w100.button-large.button-solid-norm.mt-6"));

        submitButton.Click();
    }
}