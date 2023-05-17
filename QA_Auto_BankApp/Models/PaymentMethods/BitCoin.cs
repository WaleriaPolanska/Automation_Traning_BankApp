using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class BitCoin : PaymentMethod, IPayment
{
    private string _name;
    private float _exchangeRate;

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

    public float ExchangeRate
    {
        get => _exchangeRate;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("ExchangeRate"), nameof(value));
            }

            _exchangeRate = value;
        }
    }
    
    public BitCoin(string paymentMethodName, float exchangeRate, float bitCoinAmount) : base(bitCoinAmount)
    {
        Name = paymentMethodName;
        ExchangeRate = exchangeRate;
    }

    public bool MakePayment(float amount)
    {
        var bitCoinAmount = amount / ExchangeRate;

        if (PaymentHelper.IsCanPay(bitCoinAmount, Balance))
        {
            Balance -= bitCoinAmount;

            return true;
        }

        return false;
    }

    public void TopUp(float amount) => Balance += amount / ExchangeRate;

    public float GetBalance() => Balance * ExchangeRate;

    public override string ToString() => $"    BITCOIN\nName: {Name}\nBalance: {Balance}";
}