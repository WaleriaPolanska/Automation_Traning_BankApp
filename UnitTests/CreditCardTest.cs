using QA_Auto_BankApp.Models.PaymentMethods;
using UnitTests.Helpers;

namespace UnitTests;

public class CreditCardTest
{
    [Fact]
    public void CreditCardCreditPercentageSetIsSuccessfulIfCreditPercentageIsValid()
    {
        const float expectedCreditPercentage = 4f;

        var creditCard = new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);
        var actualCreditPercentage = creditCard.CreditPercentage;

        Assert.Equal(expectedCreditPercentage, actualCreditPercentage);
    }
    
    [Fact]
    public void CreditCardCreditPercentageSetThrowsArgumentExceptionIfCreditPercentageIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), -1.1f, 4444f));
    }
    
    [Fact]
    public void CreditCardCreditLimitSetIsSuccessfulIfCreditLimitIsValid()
    {
        const float expectedCreditLimit = 4421f;

        var creditCard = new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 4421f);
        var actualCreditLimit = creditCard.CreditLimit;

        Assert.Equal(expectedCreditLimit, actualCreditLimit);
    }
    
    [Fact]
    public void CreditCardCreditLimitSetThrowsArgumentExceptionIfCreditLimitIsInvalid()
    {
        Assert.Throws<ArgumentException>(() => new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 12.1f, -4f));
    }
    
    [Fact]
    public void CreditCardToStringReturnsValidResult()
    {
        const string name = "card";
        const string cardNumber = "1111111111111111";
        const int CVV = 222;
        const float creditPercentage = 21;
        const float creditLimit = 1000;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var paymentCardAsString = PaymentCardHelper.GetPaymentCardAsString(name, cardNumber, CVV);
        
        var creditCard = new CreditCard(name, cardNumber, CVV, userInfo, creditPercentage, creditLimit);
        var expectedToString = $"    CREDIT CARD\n{paymentCardAsString}CreditLimit: {creditLimit}\nCreditPercentage: {creditPercentage}%";
        var actualToString = creditCard.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}