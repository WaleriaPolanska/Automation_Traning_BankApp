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
    public void CashToStringReturnsValidResult()
    {
        const string name = "my money";
        const float amount = 100;
        
        var expectedToString = $"    CASH\nName: {name}\nAmount: {amount}";
        
        var cash = new Cash(name, amount);
        var actualToString = cash.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
    
    [Fact]
    public void CashMakePaymentIsSuccessful()
    {
        const float expectedBalance = 1000;
        
        var cash = new Cash("cash", 5000);
        
        var isPaymentSuccessful = cash.MakePayment(4000);

        var actualBalance = cash.GetBalance();

        Assert.True(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void CashMakePaymentIsUnsuccessfulIfBalanceNotEnough()
    {
        const float expectedBalance = 1000;
        
        var cash = new Cash("cash", 1000);
        
        var isPaymentSuccessful = cash.MakePayment(3000);

        var actualBalance = cash.GetBalance();

        Assert.False(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void CashTopUpIsSuccessful()
    {
        const float expectedBalance = 15000f;
        
        var cash = new Cash("cash", 10000);
        
        cash.TopUp(5000);

        var actualBalance = cash.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void CashGetBalanceIsSuccessful()
    {
        const float expectedBalance = 10000;
        
        var cash = new Cash("cash", 10000);
        var actualBalance = cash.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
}