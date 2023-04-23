using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.PaymentMethods;
using UnitTests.Helpers;

namespace UnitTests;

public class BankClientTest
{
    [Fact]
    public void BankClientUserInfoSetIsSuccessfulIfUserInfoIsValid()
    {
        var expectedUserInfo = UserInfoHelper.GetDefaultUserInfo();

        var bankClient = new BankClient(UserInfoHelper.GetDefaultUserInfo());
        var actualUserInfo = bankClient.UserInfo;

        Assert.Equal(expectedUserInfo, actualUserInfo);
    }

    [Fact]
    public void BankClientUserInfoThrowsArgumentExceptionIfUserInfoIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new BankClient(null));
    }
    
    // [Fact]
    // public void CashbackCardToStringReturnsValidResult()
    // {
    //     var userInfo = UserInfoHelper.GetDefaultUserInfo();
    //     var paymentCardAsString = PaymentCardHelper.GetPaymentCardAsString(name, cardNumber, CVV);
    //     
    //     var bankClient = new BankClient(userInfo);
    //     
    //     bankClient.AddPaymentMethod("Cash", new Cash("cash", 1000f));
    //     var expectedToString = $"    CASHBACK CARD\n{paymentCardAsString}Balance: {balance}\nInterest: {interest}%";
    //     var actualToString = bankClient.ToString();
    //
    //     Assert.Equal(expectedToString, actualToString);
    // }
}