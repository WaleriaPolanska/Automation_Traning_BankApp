using QA_Auto_BankApp.Models.PaymentMethods;
using UnitTests.Helpers;

namespace UnitTests;

public class DebitCardTest
{
    [Fact]
    public void DebitCardInterestSetIsSuccessfulIfInterestIsValid()
    {
        const float expectedInterest = 4f;

        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);
        var actualInterest = debitCard.Interest;

        Assert.Equal(expectedInterest, actualInterest);
    }
    
    [Fact]
    public void DebitCardInterestSetThrowsArgumentExceptionIfInterestIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), -1.1f, 4444f));
    }
    
    [Fact]
    public void DebitCardDebitSetIsSuccessfulIfDebitIsValid()
    {
        const float expectedDebit = 2222f;

        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 2222f);
        var actualDebit = debitCard.Debit;

        Assert.Equal(expectedDebit, actualDebit);
    }
    
    [Fact]
    public void DebitCardDebitSetThrowsArgumentExceptionIfDebitIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 1.1f, -2f));
    }
    
    [Fact]
    public void DebitCardToStringReturnsValidResult()
    {
        const string name = "card";
        const string cardNumber = "1111111111111111";
        const int CVV = 222;
        const int interest = 22;
        const int debit = 2000;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var paymentCardAsString = PaymentCardHelper.GetPaymentCardAsString(name, cardNumber, CVV);
        
        var debitCard = new DebitCard(name, cardNumber, CVV, userInfo, interest, debit);
        var expectedToString = $"    DEBIT CARD\n{paymentCardAsString}Debit: {debit}\nInterest: {interest}%";
        var actualToString = debitCard.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
    
    [Fact]
    public void DebitCardMakePaymentIsSuccessful()
    {
        const float expectedBalance = 2000;
        
        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 2000f);
        
        var isPaymentSuccessful = debitCard.MakePayment(0f);

        var actualBalance = debitCard.GetBalance();

        Assert.True(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void DebitCardMakePaymentIsUnsuccessfulIfBalanceNotEnough()
    {
        const float expectedBalance = 2000;
        
        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 2000f);
        
        var isPaymentSuccessful = debitCard.MakePayment(20000);
        var actualBalance = debitCard.GetBalance();

        Assert.False(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void DebitCardTopUpIsSuccessful()
    {
        const float expectedBalance = 15520f;
        
        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 2000f);
        
        debitCard.TopUp(13000);

        var actualBalance = debitCard.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void DebitCardGetBalanceIsSuccessful()
    {
        const float expectedBalance = 30000f;
        
        var debitCard = new DebitCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 30000f);
        var actualBalance = debitCard.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
}