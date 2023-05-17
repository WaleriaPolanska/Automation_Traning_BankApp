using System.Text;

using QA_Auto_BankApp.Enums;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.BankClientInfo;
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
    public void BankClientUserInfoThrowsArgumentExceptionIfUserInfoIsNull() => Assert.Throws<ArgumentNullException>(() => new BankClient(null));

    [Fact]
    public void CashbackCardToStringReturnsValidResult()
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);
        var bitCoin = new BitCoin("btc", 10000, 10f);
        var creditCard = new CreditCard("creditcard", "1111111111111111", 123, userInfo, 1f, 1000f);
        var debitCard = new DebitCard("debitcard", "1111111111111111", 123, userInfo, 12f, 2000f);
        var cashbackCard = new CashbackCard("cashbackcard", "1111111111111111", 123, userInfo, 11f, 3000f);
        
        bankClient.AddPaymentMethod(cash);
        bankClient.AddPaymentMethod(cashbackCard);
        bankClient.AddPaymentMethod(debitCard);
        bankClient.AddPaymentMethod(creditCard);
        bankClient.AddPaymentMethod(bitCoin);

        var expectedStringBuilder = new StringBuilder();
        
        expectedStringBuilder.Append($"{userInfo}\n");
        expectedStringBuilder.Append($"{cash}\n");
        expectedStringBuilder.Append($"{cashbackCard}\n");
        expectedStringBuilder.Append($"{debitCard}\n");
        expectedStringBuilder.Append($"{creditCard}\n");
        expectedStringBuilder.Append($"{bitCoin}\n\n");

        var expectedString = expectedStringBuilder.ToString();
        var actualToString = bankClient.ToString();

        Assert.Equal(expectedString, actualToString);
    }
    
    [Fact]
    public void BankClientsEqualityIsValid()
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient1 = GetBankClient(userInfo);
        var bankClient2 = GetBankClient(userInfo);

        Assert.True(bankClient1.Equals(bankClient2));
    }
    
    [Fact]
    public void BankClientsEqualityIsNotValidIfSNamesAreNotEqual()
    {
        var userInfo1 = UserInfoHelper.GetDefaultUserInfo();
        var userInfo2 = UserInfoHelper.GetDefaultUserInfo();

        userInfo2.Name = "Test";
        
        var bankClient1 = GetBankClient(userInfo1);
        var bankClient2 = GetBankClient(userInfo2);

        Assert.False(bankClient1.Equals(bankClient2));
    }
    
    [Fact]
    public void BankClientsEqualityIsNotValidIfLastNamesAreNotEqual()
    {
        var userInfo1 = UserInfoHelper.GetDefaultUserInfo();
        var userInfo2 = UserInfoHelper.GetDefaultUserInfo();

        userInfo1.LastName = "Test";
        
        var bankClient1 = GetBankClient(userInfo1);
        var bankClient2 = GetBankClient(userInfo2);

        Assert.False(bankClient1.Equals(bankClient2));
    }
    
    [Fact]
    public void BankClientsEqualityIsNotValidIfAddressesAreNotEqual()
    {
        var userInfo1 = UserInfoHelper.GetDefaultUserInfo();
        var userInfo2 = UserInfoHelper.GetDefaultUserInfo();

        userInfo1.Address.City = "Test";
        
        var bankClient1 = GetBankClient(userInfo1);
        var bankClient2 = GetBankClient(userInfo2);

        Assert.False(bankClient1.Equals(bankClient2));
    }
    
    [Fact]
    public void BankClientsEqualityIsNotValidIfBalancesAreNotEqual()
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient1 = GetBankClient(userInfo);
        var bankClient2 = GetBankClient(userInfo);

        bankClient1.Pay(1f);

        Assert.False(bankClient1.Equals(bankClient2));
    }

    [Fact]
    public void BankClientTopUpIsSuccessful()
    {
        const float expectedBalance = 1100f;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = GetBankClient(userInfo);
        
        bankClient.TopUpPaymentMethod(PaymentType.Cash, "cash", 100f);

        var actualBalance = bankClient.PaymentMethodsByName[PaymentType.Cash].FirstOrDefault().GetBalance();

        Assert.Equal(expectedBalance, actualBalance);
    }
    
    [Fact]
    public void BankClientAddPaymentMethodIsSuccessful()
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);
        
        Assert.True(!bankClient.PaymentMethodsByName[PaymentType.Cash].Any());
        
        bankClient.AddPaymentMethod(cash);

        Assert.True(bankClient.PaymentMethodsByName[PaymentType.Cash].Count == 1);
    }
    
    [Fact]
    public void BankClientAddDuplicatedPaymentMethodIsNotThrowException()
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);
        
        bankClient.AddPaymentMethod(cash);

        var expectedPaymentMethodCategories = bankClient.PaymentMethodsByName.Count;
        
        bankClient.AddPaymentMethod(cash);
        
        var actualPaymentMethodCategories = bankClient.PaymentMethodsByName.Count;
        
        Assert.Equal(expectedPaymentMethodCategories, actualPaymentMethodCategories);
    }
    
    [Fact]
    public void BankClientPayIsSuccessful()
    {
        const float expectedBalanceBeforePayment = 1000f;
        const float expectedBalanceAfterPayment = 500f;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);

        bankClient.AddPaymentMethod(cash);

        var actualBalanceBeforePayment = bankClient.PaymentMethodsByName[PaymentType.Cash].FirstOrDefault().GetBalance();
        
        Assert.Equal(expectedBalanceBeforePayment, actualBalanceBeforePayment);

        var isPaymentSuccessful = bankClient.Pay(500);
        
        var actualBalanceAfterPayment = bankClient.PaymentMethodsByName[PaymentType.Cash].FirstOrDefault().GetBalance();
        
        Assert.True(isPaymentSuccessful);
        Assert.Equal(expectedBalanceAfterPayment, actualBalanceAfterPayment);
    }
    
    [Fact]
    public void BankClientPayIsUnsuccessful()
    {
        const float expectedBalanceBeforePayment = 1000f;
        const float expectedBalanceAfterPayment = 1000f;
        
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);

        bankClient.AddPaymentMethod(cash);

        var actualBalanceBeforePayment = bankClient.PaymentMethodsByName[PaymentType.Cash].FirstOrDefault().GetBalance();
        
        Assert.Equal(expectedBalanceBeforePayment, actualBalanceBeforePayment);

        var isPaymentSuccessful = bankClient.Pay(1500);
        
        var actualBalanceAfterPayment = bankClient.PaymentMethodsByName[PaymentType.Cash].FirstOrDefault().GetBalance();
        
        Assert.False(isPaymentSuccessful);
        Assert.Equal(expectedBalanceAfterPayment, actualBalanceAfterPayment);
    }
    
    private static BankClient GetBankClient(UserInfo userInfo)
    {
        var bankClient = new BankClient(userInfo);
        var cash = new Cash("cash", 1000f);
        var bitCoin = new BitCoin("btc", 10000, 10f);
        var creditCard = new CreditCard("creditcard", "1111111111111111", 123, userInfo, 1f, 1000f);
        var debitCard = new DebitCard("debitcard", "1111111111111111", 123, userInfo, 12f, 2000f);
        var cashbackCard = new CashbackCard("cashbackcard", "1111111111111111", 123, userInfo, 11f, 3000f);
        
        bankClient.AddPaymentMethod(cash);
        bankClient.AddPaymentMethod(bitCoin);
        bankClient.AddPaymentMethod(creditCard);
        bankClient.AddPaymentMethod(debitCard);
        bankClient.AddPaymentMethod(cashbackCard);

        return bankClient;
    }
}