using OpenQA.Selenium;

namespace SeleniumTests.Pages;

public class NewMessagePage
{
    private readonly IWebDriver _driver;
    
    public NewMessagePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void SendMessage(string emailText, string? toFieldText = null, string? subjectText = null)
    {
        if (toFieldText != null)
        {
            var toField = _driver.FindElement(By.XPath("//*[@data-testid='composer:to']"));
            
            toField.Click();
            toField.SendKeys(toFieldText);
            toField.SendKeys(Keys.Escape);   
        }

        if (subjectText != null)
        {
            var subjectField = _driver.FindElement(By.XPath("//*[@data-testid='composer:subject']"));
            
            subjectField.Click();

            subjectField.SendKeys(subjectText);   
        }
        
        var emailBodyIframe = _driver.FindElement(By.XPath("//*[@data-testid='rooster-iframe']"));

        _driver.SwitchTo().Frame(emailBodyIframe);
        
        var emailBody = _driver.FindElement(By.Id("rooster-editor"));
        
        emailBody.Clear();
        emailBody.SendKeys(emailText);
        
        _driver.SwitchTo().DefaultContent();

        var sendEmailButton = _driver.FindElement(By.XPath("//*[@data-testid='composer:send-button']"));
        
        sendEmailButton.Click();
        
        Thread.Sleep(3000);
    }
}