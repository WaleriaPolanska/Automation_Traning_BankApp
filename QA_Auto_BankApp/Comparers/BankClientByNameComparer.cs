using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientByNameComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null)
        {
            if (y is null)
            {
                return 0;
            }
            
            return -1;
        }
        
        if (y is null)
        {
            return 1;
        }

        return string.Compare(x.UserInfo.Name, y.UserInfo.Name, StringComparison.Ordinal);
    }
}