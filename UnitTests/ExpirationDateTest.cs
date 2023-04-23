using QA_Auto_BankApp.Models.PaymentMethods;

namespace UnitTests;

public class ExpirationDateTest
{
    [Fact]
    public void ExpirationDateToStringReturnsValidResult()
    {
        var expectedDate = DateTime.Now.AddYears(4);
        var expectedToString = $"{expectedDate.Month}/{expectedDate.Year}";
        
        var expirationDate = new ExpirationDate();
        var actualToString = expirationDate.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}