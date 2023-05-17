using QA_Auto_BankApp.Models.PaymentMethods;

using UnitTests.Helpers;

namespace UnitTests;

public class CreditCardTest
{
    [Fact]
    public void CreditCardCreditPercentageSetIsSuccessfulIfCreditPercentageIsValid()
    {
        const float expectedCreditPercentage = 4f;

        var creditCard =
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);
        var actualCreditPercentage = creditCard.CreditPercentage;

        Assert.Equal(expectedCreditPercentage, actualCreditPercentage);
    }

    [Fact]
    public void CreditCardCreditPercentageSetThrowsArgumentExceptionIfCreditPercentageIsInvalid() =>
        Assert.Throws<ArgumentException>(() =>
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), -1.1f, 4444f));

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
        var expectedToString =
            $"    CREDIT CARD\n{paymentCardAsString}CreditLimit: {creditLimit}\nCreditPercentage: {creditPercentage}%";
        var actualToString = creditCard.ToString();

        Assert.Equal(expectedToString, actualToString);
    }

    [Fact]
    public void CreditCardMakePaymentIsSuccessful()
    {
        const float expectedBalance = 2880;

        var creditCard =
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 6000f);

        var isPaymentSuccessful = creditCard.MakePayment(3000);

        var actualBalance = creditCard.GetBalance();

        Assert.True(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void CreditCardMakePaymentIsUnsuccessfulIfBalanceNotEnough()
    {
        const float expectedBalance = 1000;

        var creditCard =
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);

        var isPaymentSuccessful = creditCard.MakePayment(10000);
        var actualBalance = creditCard.GetBalance();

        Assert.False(isPaymentSuccessful);
        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void CreditCardTopUpIsSuccessful()
    {
        const float expectedBalance = 5000f;

        var creditCard =
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 1000f);

        creditCard.TopUp(4000);

        var actualBalance = creditCard.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void CreditCardGetBalanceIsSuccessful()
    {
        const float expectedBalance = 3000f;

        var creditCard =
            new CreditCard("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo(), 4f, 3000f);
        var actualBalance = creditCard.GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
}