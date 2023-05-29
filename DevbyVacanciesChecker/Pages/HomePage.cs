using OpenQA.Selenium;

namespace DevbyVacanciesChecker.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly IWebElement _vacanciesButton;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _driver.Navigate().GoToUrl("https://devby.io");
        
        _vacanciesButton = _driver.FindElement(By.LinkText("Вакансии"));
    }

    public int GetTotalVacanciesCount()
    {
        return int.Parse(_vacanciesButton.GetAttribute("data-label"));
    }

    public void NavigateToVacanciesPage()
    {
        _vacanciesButton.Click();
    }
}