using DevbyVacanciesChecker.Pages;

namespace DevbyVacanciesChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var driver = WebDriver.GetInstance();

            var homePage = new HomePage(driver);
            var totalCountOfVacanciesFromHomePage = homePage.GetTotalVacanciesCount();

            homePage.NavigateToVacanciesPage();

            var vacanciesPage = new VacanciesPage(driver);

            vacanciesPage.CloseWishesPopup();

            var vacanciesNumberByName = vacanciesPage.GetVacanciesNumberByName();

            PrintVacanciesNameAndCountByDescending(vacanciesNumberByName);

            var totalCountOfVacanciesFromSections = vacanciesNumberByName.Values.Sum(x => x);

            PrintAreVacanciesCountFromHomePageAndFromSectionsEqual(totalCountOfVacanciesFromHomePage,
                totalCountOfVacanciesFromSections);
        }

        private static void PrintVacanciesNameAndCountByDescending(Dictionary<string, int> vacanciesNumberByName)
        {
            var orderedVacanciesNumberByName = vacanciesNumberByName.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (name, number) in orderedVacanciesNumberByName)
            {
                Console.WriteLine($"{name} - {number}");
            }
        }

        private static void PrintAreVacanciesCountFromHomePageAndFromSectionsEqual(
            int totalCountOfVacanciesFromHomePage, int totalCountOfVacanciesFromSections)
        {
            Console.WriteLine(
                $"Is sum of vacancies equals to total vacancies number on main page: {totalCountOfVacanciesFromHomePage == totalCountOfVacanciesFromSections}");
        }
    }
}