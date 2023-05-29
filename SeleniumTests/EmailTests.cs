using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

using SeleniumTests.Pages;

namespace SeleniumTests;

public class Tests
{
    private const string? FirstAccountEmail = "wal-test-qa-mail1@proton.me";
    private const string? SecondAccountEmail = "wal-test-qa-mail2@proton.me";
    private const string FirstAccountPassword = "wal-test-qa-mail1";
    private const string SecondAccountPassword = "wal-test-qa-mail2";
    private static IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new EdgeDriver();

        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void ValidateEmailSendAndReply()
    {
        const int emailWaitTimeoutInMinutes = 10;

        var loginPage = new LoginPage(_driver);

        loginPage.Login(FirstAccountEmail, FirstAccountPassword);

        var inboxPage = new InboxPage(_driver);

        inboxPage.OpenNewMessageEditor();

        var newMessagePage = new NewMessagePage(_driver);
        var subjectText = Guid.NewGuid().ToString("n");
        const string emailText = "Hi. This is test";

        newMessagePage.SendMessage(emailText, SecondAccountEmail, subjectText);
        inboxPage.LogOut();
        loginPage.Login(SecondAccountEmail, SecondAccountPassword);
        inboxPage.OpenEmailElementBySubjectWithinMinutes(subjectText, emailWaitTimeoutInMinutes);

        var messagePage = new MessagePage(_driver);
        var actualEmail = messagePage.GetEmailText();
        
        Assert.That(actualEmail, Is.EqualTo(emailText));
        
        messagePage.ClickReply();

        const string responseText = "Hi. Got it";
        
        newMessagePage.SendMessage(responseText);

        inboxPage.LogOut();
        loginPage.Login(FirstAccountEmail, FirstAccountPassword);
        inboxPage.OpenEmailElementBySubjectWithinMinutes(subjectText, emailWaitTimeoutInMinutes);

        var actualResponse = messagePage.GetEmailText();
        
        Assert.That(actualResponse, Is.EqualTo(responseText));
    }
}