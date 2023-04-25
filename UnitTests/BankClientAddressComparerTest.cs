using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.BankClientInfo;

using UnitTests.Helpers;

namespace UnitTests;

public class BankClientAddressComparerTest
{
    [Theory, MemberData(nameof(AddressData))]
    public void BankClientsCompareIsSuccessfulWithDifferentAddressData(Address address1, Address address2,
        int expectedResult)
    {
        var userInfo1 = new UserInfo("Jackie", "Chan", address1, "+77777777777");
        var userInfo2 = new UserInfo("Jackie", "Chan", address2, "+77777777777");


        var bankClient1 = new BankClient(userInfo1);
        var bankClient2 = new BankClient(userInfo2);

        var bankClientByNameComparer = new BankClientAddressComparer();
        var actualResult = bankClientByNameComparer.Compare(bankClient1, bankClient2);

        Assert.Equal(expectedResult, actualResult);
    }
    
    [Theory, MemberData(nameof(BankInvalidData))]
    public void BankClientsCompareIsThrowsArgumentExceptionIfDataIsInvalid(BankClient bankClient1, BankClient bankClient2)
    {
        var bankClientByNameComparer = new BankClientAddressComparer();
        
        Assert.Throws<ArgumentNullException>(() => bankClientByNameComparer.Compare(bankClient1, bankClient2));
    }
    
    public static IEnumerable<object[]> BankInvalidData => new List<object[]>
    {
        new object[] { null, new BankClient(UserInfoHelper.GetDefaultUserInfo())},
        new object[] { new BankClient(UserInfoHelper.GetDefaultUserInfo()), null},
        new object[] { null, null}
    };

    public static IEnumerable<object[]> AddressData => new List<object[]>
    {
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            0
        },
        new object[]
        {
            new Address("Snejnaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            3
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Solnechnaya", 2222, "Warsaw", "Poland", 222, 111),
            -3
        },
        new object[]
        {
            new Address("Polevaya", 2225, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            1
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2223, "Warsaw", "Poland", 222, 111),
            -1
        },
        new object[]
        {
            new Address("Polevaya", 2222, "York-New", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            2
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "York", "Poland", 222, 111),
            -2
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Somali", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            3
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Zimbabwe", 222, 111),
            -10
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 225, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            1
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 223, 111),
            -1
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 115),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 112),
            1
        },
        new object[]
        {
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 11),
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111),
            -1
        }
    };
}