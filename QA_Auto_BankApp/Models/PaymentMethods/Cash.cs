using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class Cash : PaymentMethod, IPayment
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 20)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Name"), nameof(value));
            }

            _name = value;
        }
    }

    public Cash(string paymentMethodName, float cashBalance) : base(cashBalance)
    {
        Name = paymentMethodName;
    }

    public bool MakePayment(float amount)
    {
        if (PaymentHelper.IsCanPay(amount, Balance))
        {
            Balance -= amount;

            return true;
        }

        return false;
    }

    public void TopUp(float amount) => Balance += amount;

    public float GetBalance() => Balance;

    public override string ToString() => $"    CASH\nName: {Name}\nAmount: {Balance}";
}