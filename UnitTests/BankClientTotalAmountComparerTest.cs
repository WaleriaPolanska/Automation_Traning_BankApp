using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.PaymentMethods;

using UnitTests.Helpers;

namespace UnitTests;

public class BankClientTotalAmountComparerTest
{
    [Theory, MemberData(nameof(MoneyData))]
    public void BankClientsCompareIsSuccessfulWithDifferentMoneyAmounts(float cashAmount1, float cashAmount2, int expectedResult)
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient1 = new BankClient(userInfo);
        var bankClient2 = new BankClient(userInfo);
        
        bankClient1.AddPaymentMethod("Cash", new Cash("cash", cashAmount1));
        bankClient2.AddPaymentMethod("Cash", new Cash("cash", cashAmount2));

        var bankClientByNameComparer = new BankClientTotalAmountComparer();
        var actualResult = bankClientByNameComparer.Compare(bankClient1, bankClient2);
        
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory, MemberData(nameof(BankInvalidData))]
    public void BankClientsCompareIsThrowsArgumentExceptionIfDataIsInvalid(BankClient bankClient1, BankClient bankClient2)
    {
        var bankClientByNameComparer = new BankClientTotalAmountComparer();
        
        Assert.Throws<ArgumentNullException>(() => bankClientByNameComparer.Compare(bankClient1, bankClient2));
    }
    
    public static IEnumerable<object[]> BankInvalidData => new List<object[]>
    {
        new object[] { null, new BankClient(UserInfoHelper.GetDefaultUserInfo())},
        new object[] { new BankClient(UserInfoHelper.GetDefaultUserInfo()), null},
        new object[] { null, null}
    };

    public static IEnumerable<object[]> MoneyData => new List<object[]>
    {
        new object[]
        {
            100,
            101,
            -1
        },
        new object[]
        {
            100,
            100,
            0
        },
        new object[]
        {
            101,
            100,
            1
        }
    };
}