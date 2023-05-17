using QA_Auto_BankApp.Enums;
using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientNumberOfCardsComparer : IComparer<BankClient>
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

        var xBankClientCountOfCards = 0;
        var yBankClientCountOfCards = 0;

        foreach (var key in x.PaymentMethodsByName.Keys)
        {
            if (key is PaymentType.DebitCard or PaymentType.CreditCard or PaymentType.CashbackCard)
            {
                xBankClientCountOfCards += x.PaymentMethodsByName[key].Count;
            }
        }

        foreach (var key in y.PaymentMethodsByName.Keys)
        {
            if (key is PaymentType.DebitCard or PaymentType.CreditCard or PaymentType.CashbackCard)
            {
                yBankClientCountOfCards += y.PaymentMethodsByName[key].Count;
            }
        }

        return xBankClientCountOfCards.CompareTo(yBankClientCountOfCards);
    }
}