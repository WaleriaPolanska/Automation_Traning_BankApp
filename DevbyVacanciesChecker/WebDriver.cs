using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace DevbyVacanciesChecker;

public static class WebDriver
{
    private static IWebDriver? _driver;
    
    public static IWebDriver GetInstance()
    {
        if (_driver is null)
        {
            _driver = new EdgeDriver();
        
            _driver.Manage().Window.Maximize(); 
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        return _driver;
    }
}