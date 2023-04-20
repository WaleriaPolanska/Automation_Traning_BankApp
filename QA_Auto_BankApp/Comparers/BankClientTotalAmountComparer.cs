using QA_Auto_BankApp.Models;

namespace QA_Auto_BankApp.Comparers;

public class BankClientTotalAmountComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentNullException();
        }

        var xBankClientTotalAmount = 0f;
        var yBankClientTotalAmount = 0f;

        foreach (var key in x.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in x.PaymentMethodsByName[key])
            {
                xBankClientTotalAmount += paymentMethod.GetBalance();
            }
        }

        foreach (var key in y.PaymentMethodsByName.Keys)
        {
            foreach (var paymentMethod in y.PaymentMethodsByName[key])
            {
                yBankClientTotalAmount += paymentMethod.GetBalance();
            }
        }

        return xBankClientTotalAmount.CompareTo(yBankClientTotalAmount);
    }
}