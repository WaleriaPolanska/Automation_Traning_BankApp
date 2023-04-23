using QA_Auto_BankApp.Models.PaymentMethods;

namespace UnitTests;

public class CashTest
{
    [Fact]
    public void CashNameSetIsSuccessfulIfNameIsValid()
    {
        const string expectedName = "Money for vacation";
        
        var cash = new Cash("Money for vacation", 20000);
        var actualName = cash.Name;
        
        Assert.Equal(expectedName, actualName);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaa1")]
    public void CashNameSetThrowsArgumentExceptionIfNameIsInvalid(string name)
    {
        Assert.Throws<ArgumentException>(() => new Cash(name, 10000));
    }
    
    [Fact]
    public void CashAmountSetIsSuccessfulIfAmountIsValid()
    {
        const float expectedAmount = 10000;
        
        var cash = new Cash("My Cash", 10000);
        var actualAmount = cash.Amount;
        
        Assert.Equal(expectedAmount, actualAmount);
    }
    
    [Fact]
    public void CashAmountSetThrowsArgumentExceptionIfAmountIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new Cash("My Cash", -1f));
    }
    
    [Fact]
    public void CashToStringReturnsValidResult()
    {
        const string name = "my money";
        const float amount = 100;
        
        var expectedToString = $"    CASH\nName: {name}\nAmount: {amount}";
        
        var cash = new Cash(name, amount);
        var actualToString = cash.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}