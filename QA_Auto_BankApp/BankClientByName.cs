namespace QA_Auto_BankApp;

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