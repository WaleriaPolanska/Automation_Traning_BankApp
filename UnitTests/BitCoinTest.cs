using QA_Auto_BankApp.Models.PaymentMethods;

namespace UnitTests;

public class BitCoinTest
{
    [Fact]
    public void BitCoinNameSetIsSuccessfulIfNameIsValid()
    {
        const string expectedName = "My BTC";
        
        var bitCoin = new BitCoin("My BTC", 10000, 0.5f);
        var actualName = bitCoin.Name;
        
        Assert.Equal(expectedName, actualName);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaa1")]
    public void BitCoinNameSetThrowsArgumentExceptionIfNameIsInvalid(string name)
    {
        Assert.Throws<ArgumentException>(() => new BitCoin(name, 10000, 1f));
    }
    
    [Fact]
    public void BitCoinExchangeRateSetIsSuccessfulIfExchangeRateIsValid()
    {
        const float expectedExchangeRate = 10000;
        
        var bitCoin = new BitCoin("My BTC", 10000, 0.5f);
        var actualExchangeRate = bitCoin.ExchangeRate;
        
        Assert.Equal(expectedExchangeRate, actualExchangeRate);
    }
    
    [Fact]
    public void BitCoinExchangeRateSetThrowsArgumentExceptionIfExchangeRateIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new BitCoin("BTC", -1f, 1f));
    }
    
    [Fact]
    public void BitCoinBalanceSetIsSuccessfulIfBalanceIsValid()
    {
        const float expectedBalance = 0.5f;
        
        var bitCoin = new BitCoin("My BTC", 10000, 0.5f);
        var actualBalance = bitCoin.Balance;
        
        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void BitCoinBalanceSetThrowsArgumentExceptionIfBalanceIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new BitCoin("BTC", 10000, -1f));
    }
    
    [Fact]
    public void BitCoinToStringReturnsValidResult()
    {
        const string name = "BTC";
        const float balance = 10;
        
        var expectedToString = $"    BITCOIN\nName: {name}\nBalance: {balance}";
        
        var bitCoin = new BitCoin(name, 10000, balance);
        var actualToString = bitCoin.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}