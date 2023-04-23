using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class Cash : IPayment
{
    private string _name;
    private float _amount;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 20)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Name"), nameof(value));
            }

            _name = value;
        }
    }
    
    public float Amount
    {
        get { return _amount; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Amount"), nameof(value));
            }

            _amount = value;
        }
    }

    public Cash(string paymentMethodName, float cashAmount)
    {
        Name = paymentMethodName;
        Amount = cashAmount;
    }

    public bool MakePayment(float amount)
    {
        if (IPayment.IsCanPay(amount, Amount))
        {
            Amount -= amount;

            return true;
        }

        return false;
    }

    public void TopUp(float amount)
    {
        Amount += amount;
    }

    public float GetBalance()
    {
        return Amount;
    }
    
    public override string ToString()
    {
        return $"    CASH\nName: {Name}\nAmount: {Amount}";
    }
}