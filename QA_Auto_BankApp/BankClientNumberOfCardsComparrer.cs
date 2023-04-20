namespace QA_Auto_BankApp;

public class BankClientNumberOfCardsComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentNullException();
        }

        var xBankClientCountOfCards = 0;
        var yBankClientCountOfCards = 0;

        foreach (var key in x.PaymentMethodsByName.Keys)
        {
            if (key is "DebitCard" or "CreditCard" or "CashbackCard")
            {
                xBankClientCountOfCards += x.PaymentMethodsByName[key].Count;
            }
        }

        foreach (var key in y.PaymentMethodsByName.Keys)
        {
            if (key is "DebitCard" or "CreditCard" or "CashbackCard")
            {
                yBankClientCountOfCards += y.PaymentMethodsByName[key].Count;
            }
        }

        return xBankClientCountOfCards.CompareTo(yBankClientCountOfCards);
    }
}