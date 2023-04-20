using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientMaxAmountOnOnePayMethodComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentNullException();
        }

        var xBankClientMaxAmountOnOnePayMethod = 0f;
        var yBankClientMaxAmountOnOnePayMethod = 0f;

        foreach (var key in x.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in x.PaymentMethodsByName[key])
            {
                if (xBankClientMaxAmountOnOnePayMethod < paymentMethod.GetBalance())
                {
                    xBankClientMaxAmountOnOnePayMethod = paymentMethod.GetBalance();
                }
            }
        }

        foreach (var key in y.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in y.PaymentMethodsByName[key])
            {
                if (yBankClientMaxAmountOnOnePayMethod < paymentMethod.GetBalance())
                {
                    yBankClientMaxAmountOnOnePayMethod = paymentMethod.GetBalance();
                }
            }
        }

        return xBankClientMaxAmountOnOnePayMethod.CompareTo(yBankClientMaxAmountOnOnePayMethod);
    }
}