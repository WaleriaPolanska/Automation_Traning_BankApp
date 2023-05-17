using QA_Auto_BankApp.Helpers;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public abstract class PaymentMethod
{
    private float _balance;
    
    public float Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Balance"), nameof(value));
            }

            _balance = value;
        }
    }

    public PaymentMethod(float balance)
    {
        Balance = balance;
    }
}