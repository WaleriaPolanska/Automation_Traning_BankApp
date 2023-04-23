using QA_Auto_BankApp.Models.BankClientInfo;

namespace UnitTests.Helpers;

public static class UserInfoHelper
{
    public static UserInfo GetDefaultUserInfo()
    {
        return new UserInfo("Jackie", "Chan", 
            new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111), 
            "+77777777777");
    }
}