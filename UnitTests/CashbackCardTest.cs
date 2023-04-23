using QA_Auto_BankApp.Models.PaymentMethods;
using UnitTests.Helpers;

namespace UnitTests;

public class CashbackCardTest
{
    [Fact]
    public void CashbackCardInterestSetIsSuccessfulIfInterestIsValid()
    {
        const float expectedInterest = 4f;

        var cashbackCard = new CashbackCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);
        var actualInterest = cashbackCard.Interest;

        Assert.Equal(expectedInterest, actualInterest);
    }
    
    [Fact]
    public void CashbackCardInterestSetThrowsArgumentExceptionIfInterestIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new CashbackCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), -1f, 4444f));
    }
    
    [Fact]
    public void CashbackCardBalanceSetIsSuccessfulIfBalanceIsValid()
    {
        const float expectedBalance = 1000f;

        var cashbackCard = new CashbackCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);
        var actualBalance = cashbackCard.Balance;

        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void CashbackCardBalanceSetThrowsArgumentExceptionIfBalanceIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new CashbackCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 10f, -1f));
    }
    
    [Fact]
    public void CashbackCardToStringReturnsValidResult()
    {
        const string name = "card";
        const string cardNumber = "1111111111111111";
        const int CVV = 222;
        const float interest = 21;
        const float balance = 2000;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var paymentCardAsString = PaymentCardHelper.GetPaymentCardAsString(name, cardNumber, CVV);
        
        var cashbackCard = new CashbackCard(name, cardNumber, CVV, userInfo, interest, balance);
        var expectedToString = $"    CASHBACK CARD\n{paymentCardAsString}Balance: {balance}\nInterest: {interest}%";
        var actualToString = cashbackCard.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}