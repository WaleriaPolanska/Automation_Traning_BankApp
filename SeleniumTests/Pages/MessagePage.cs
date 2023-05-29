using OpenQA.Selenium;

namespace SeleniumTests.Pages;

public class MessagePage
{
    private readonly IWebDriver _driver;

    public MessagePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void ClickReply()
    {
        var replyButton = _driver.FindElement(By.XPath("//*[@data-testid='message-view:reply']"));
    
        replyButton.Click();
    }

    public string GetEmailText()
    {
        var emailMessageIframe = _driver.FindElement(By.XPath("//*[@data-testid='content-iframe']"));

        _driver.SwitchTo().Frame(emailMessageIframe);
        
        var emailText = _driver.FindElement(By.XPath("//*[@id=\"proton-root\"]/div/div/div[1]")).Text;
        
        _driver.SwitchTo().DefaultContent();

        return emailText;
    }
}