using UnitTests.Helpers;
using UnitTests.Models;

namespace UnitTests;

public class PaymentCardTest
{
    [Fact]
    public void PaymentCardNameSetIsSuccessfulIfNameIsValid()
    {
        const string expectedName = "card";

        var paymentCard = new PaymentCardTesting("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo());
        var actualName = paymentCard.Name;

        Assert.Equal(expectedName, actualName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaa1")]
    public void PaymentCardNameSetThrowsArgumentExceptionIfNameIsInvalid(string name)
    {
        Assert.Throws<ArgumentException>(() => new PaymentCardTesting(name, "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo()));
    }
    
    [Fact]
    public void PaymentCardNumberSetIsSuccessfulIfNumberIsValid()
    {
        const string expectedNumber = "1111111111111111";

        var paymentCard = new PaymentCardTesting("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo());
        var actualNumber = paymentCard.CardNumber;

        Assert.Equal(expectedNumber, actualNumber);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("111111111111111")]
    [InlineData("11111111111111111")]
    public void PaymentCardNumberSetThrowsArgumentExceptionIfNumberIsInvalid(string number)
    {
        Assert.Throws<ArgumentException>(() => new PaymentCardTesting("my card", number, 222, UserInfoHelper.GetDefaultUserInfo()));
    }
    
    [Fact]
    public void PaymentCardCVVSetIsSuccessfulIfCVVIsValid()
    {
        const int expectedCVV = 222;

        var paymentCard = new PaymentCardTesting("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo());
        var actualCVV = paymentCard.CVV;

        Assert.Equal(expectedCVV, actualCVV);
    }

    [Theory]
    [InlineData(22)]
    [InlineData(4444)]
    public void PaymentCardCVVSetThrowsArgumentExceptionIfCVVIsInvalid(int CVV)
    {
        Assert.Throws<ArgumentException>(() => new PaymentCardTesting("my card", "1111111111111111", CVV, UserInfoHelper.GetDefaultUserInfo()));
    }
    
    [Fact]
    public void PaymentCardUserInfoSetIsSuccessfulIfUserInfoIsValid()
    {
        var expectedUserInfo = UserInfoHelper.GetDefaultUserInfo();

        var paymentCard = new PaymentCardTesting("card", "1111111111111111", 222, UserInfoHelper.GetDefaultUserInfo());
        var actualUserInfo = paymentCard.UserInfo;

        Assert.Equal(expectedUserInfo, actualUserInfo);
    }

    [Fact]
    public void PaymentCardUserInfoThrowsArgumentExceptionIfUserInfoIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new PaymentCardTesting("my card", "1111111111111111", 111, null));
    }
    
    [Fact]
    public void PaymentCardToStringReturnsValidResult()
    {
        const string name = "card";
        const string cardNumber = "1111111111111111";
        const int CVV = 222;

        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var expectedToString = PaymentCardHelper.GetPaymentCardAsString(name, cardNumber, CVV);
        
        var paymentCard = new PaymentCardTesting(name, cardNumber, CVV, userInfo);
        var actualToString = paymentCard.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}