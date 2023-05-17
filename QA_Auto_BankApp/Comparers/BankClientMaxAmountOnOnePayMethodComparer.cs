using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientMaxAmountOnOnePayMethodComparer : IComparer<BankClient>
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

        var xBankClientMaxAmountOnOnePayMethod = 0f;
        var yBankClientMaxAmountOnOnePayMethod = 0f;

        foreach (var key in x.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in x.PaymentMethodsByName[key])
            {
                var balance = paymentMethod.GetBalance();
                
                if (xBankClientMaxAmountOnOnePayMethod < balance)
                {
                    xBankClientMaxAmountOnOnePayMethod = balance;
                }
            }
        }

        foreach (var key in y.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in y.PaymentMethodsByName[key])
            {
                var balance = paymentMethod.GetBalance();
                
                if (yBankClientMaxAmountOnOnePayMethod < balance)
                {
                    yBankClientMaxAmountOnOnePayMethod = balance;
                }
            }
        }

        return xBankClientMaxAmountOnOnePayMethod.CompareTo(yBankClientMaxAmountOnOnePayMethod);
    }
}