using OpenQA.Selenium;

namespace SeleniumTests.Pages;

public class InboxPage
{
    private readonly IWebDriver _driver;
    
    public InboxPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void OpenNewMessageEditor()
    {
        var newMessageButton = _driver.FindElement(By.XPath("//*[@data-testid='sidebar:compose']"));
    
        newMessageButton.Click();
    }

    public void LogOut()
    {
        var userMenu = _driver.FindElement(By.XPath("//*[@data-testid='heading:userdropdown']"));

        userMenu.Click();

        var logoutButton = _driver.FindElement(By.XPath("//*[@data-testid='userdropdown:button:logout']"));

        logoutButton.Click();
    }
    
    public void OpenEmailElementBySubjectWithinMinutes(string? subject, int minutes)
    {
        var minutesWaited = 0;
        
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        
        while (minutesWaited <= minutes)
        {
            try
            {
                var email = _driver.FindElement(By.XPath($"//*[@data-testid='message-item:{subject}']"));

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                email.Click();

                return;
            }
            catch
            {
                minutesWaited++;
            }
        }

        throw new NotFoundException("Can't find email");
    }
}