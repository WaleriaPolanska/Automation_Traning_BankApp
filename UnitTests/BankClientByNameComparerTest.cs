using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;

using UnitTests.Helpers;

namespace UnitTests;

public class BankClientByNameComparerTest
{
    [Theory, MemberData(nameof(NamesData))]
    public void BankClientsCompareIsSuccessfulWithDifferentNames(string name, int expectedResult)
    {
        var userInfo1 = UserInfoHelper.GetDefaultUserInfo();
        var userInfo2 = UserInfoHelper.GetDefaultUserInfo();

        userInfo1.Name = name;
        
        var bankClient1 = new BankClient(userInfo1);
        var bankClient2 = new BankClient(userInfo2);

        var bankClientByNameComparer = new BankClientByNameComparer();
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

    public static IEnumerable<object[]> NamesData => new List<object[]>
    {
        new object[] { "Adam", -9 },
        new object[] { "Jackie", 0 },
        new object[] { "Tom", 10 }
    };
}