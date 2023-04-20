using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientByNameComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentNullException();
        }

        return string.Compare(x.UserInfo.Name, y.UserInfo.Name, StringComparison.Ordinal);
    }
}