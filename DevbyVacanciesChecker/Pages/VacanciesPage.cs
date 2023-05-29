using OpenQA.Selenium;

namespace DevbyVacanciesChecker.Pages;

public class VacanciesPage
{
    private readonly IWebDriver _driver;

    public VacanciesPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void CloseWishesPopup()
    {
        var closeWishesPopupButton =
            _driver.FindElement(By.CssSelector("button.wishes-popup__button-close.wishes-popup__button-close_icon"));
        
        closeWishesPopupButton.Click();
    }

    public Dictionary<string, int> GetVacanciesNumberByName()
    {
        var vacanciesNumberByName = new Dictionary<string, int>();
        var specializations = _driver.FindElements(By.CssSelector("span.radio"));

        foreach (var specialization in specializations)
        {
            specialization.Click();

            Thread.Sleep(1000);

            var vacanciesCount = int.Parse(_driver.FindElement(By.CssSelector("h1.vacancies-list__header-title")).Text
                .Split(" ").First());

            vacanciesNumberByName.Add(specialization.Text, vacanciesCount);
        }

        return vacanciesNumberByName;
    }
}