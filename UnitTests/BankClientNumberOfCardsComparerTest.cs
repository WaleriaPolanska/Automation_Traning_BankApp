using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.PaymentMethods;

using UnitTests.Helpers;

namespace UnitTests;

public class BankClientNumberOfCardsComparerTest
{
    [Theory, MemberData(nameof(CardsData))]
    public void BankClientsCompareIsSuccessfulWithDifferentCardsNumber(int numberOfCards1, int numberOfCards2, int expectedResult)
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var bankClient1 = new BankClient(userInfo);
        var bankClient2 = new BankClient(userInfo);

        for (var i = 0; i < numberOfCards1; i++)
        {
            bankClient1.AddPaymentMethod(new DebitCard($"debitCard_{numberOfCards1}", "1111111111111111", 111, userInfo, 1f, 222));    
        }
        
        for (var i = 0; i < numberOfCards2; i++)
        {
            bankClient2.AddPaymentMethod(new DebitCard($"debitCard_{numberOfCards2}", "1111111111111111", 111, userInfo, 1f, 222));    
        }

        var bankClientByNameComparer = new BankClientNumberOfCardsComparer();
        var actualResult = bankClientByNameComparer.Compare(bankClient1, bankClient2);
        
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory, MemberData(nameof(BankValidData))]
    public void BankClientsCompareIsThrowsArgumentExceptionIfDataIsInvalid(BankClient bankClient1, BankClient bankClient2, 
        int expectedResult)
    {
        var bankClientByNameComparer = new BankClientAddressComparer();
        var actualResult = bankClientByNameComparer.Compare(bankClient1, bankClient2);

        Assert.Equal(expectedResult, actualResult);
    }
    
    public static IEnumerable<object[]> BankValidData => new List<object[]>
    {
        new object[] { null, new BankClient(UserInfoHelper.GetDefaultUserInfo()), -1},
        new object[] { new BankClient(UserInfoHelper.GetDefaultUserInfo()), null, 1},
        new object[] { null, null, 0}
    };

    public static IEnumerable<object[]> CardsData => new List<object[]>
    {
        new object[] { 1, 2, -1},
        new object[] { 1, 1, 0},
        new object[] { 3, 2, 1}
    };
}