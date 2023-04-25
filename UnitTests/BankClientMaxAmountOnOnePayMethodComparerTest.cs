using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.PaymentMethods;

using UnitTests.Helpers;

namespace UnitTests;

public class BankClientMaxAmountOnOnePayMethodComparerTest
{
    [Theory, MemberData(nameof(PaymentData))]
    public void BankClientsCompareIsSuccessfulWithDifferentMaxAmountOnOnePaymentMethod(float amount1, float amount2, int expectedResult)
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient1 = new BankClient(userInfo);
        var bankClient2 = new BankClient(userInfo);

        bankClient1.AddPaymentMethod("DebitCard", new DebitCard($"debitCard", "1111111111111111", 111, userInfo, 1f, amount1));
        bankClient2.AddPaymentMethod("Cash", new Cash("cash", amount2));

        var bankClientByNameComparer = new BankClientMaxAmountOnOnePayMethodComparer();
        var actualResult = bankClientByNameComparer.Compare(bankClient1, bankClient2);
        
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory, MemberData(nameof(BankInvalidData))]
    public void BankClientsCompareIsThrowsArgumentExceptionIfDataIsInvalid(BankClient bankClient1, BankClient bankClient2)
    {
        var bankClientByNameComparer = new BankClientMaxAmountOnOnePayMethodComparer();
        
        Assert.Throws<ArgumentNullException>(() => bankClientByNameComparer.Compare(bankClient1, bankClient2));
    }
    
    public static IEnumerable<object[]> BankInvalidData => new List<object[]>
    {
        new object[] { null, new BankClient(UserInfoHelper.GetDefaultUserInfo())},
        new object[] { new BankClient(UserInfoHelper.GetDefaultUserInfo()), null},
        new object[] { null, null}
    };

    public static IEnumerable<object[]> PaymentData => new List<object[]>
    {
        new object[] { 100, 101, -1},
        new object[] { 100, 100, 0},
        new object[] { 101, 100, 1}
    };
}