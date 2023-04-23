using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class BitCoin : IPayment
{
    private string _name;
    private float _balance;
    private float _exchangeRate;

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

    public float Balance
    {
        get { return _balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Balance"), nameof(value));
            }

            _balance = value;
        }
    }

    public float ExchangeRate
    {
        get { return _exchangeRate; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("ExchangeRate"), nameof(value));
            }

            _exchangeRate = value;
        }
    }
    
    public BitCoin(string paymentMethodName, float exchangeRate, float bitCoinAmount)
    {
        Name = paymentMethodName;
        Balance = bitCoinAmount;
        ExchangeRate = exchangeRate;
    }

    public bool MakePayment(float amount)
    {
        var bitCoinAmount = amount / ExchangeRate;

        if (IPayment.IsCanPay(bitCoinAmount, Balance))
        {
            Balance -= bitCoinAmount;

            return true;
        }

        return false;
    }

    public void TopUp(float amount)
    {
        Balance += amount / ExchangeRate;
    }

    public float GetBalance()
    {
        return Balance * ExchangeRate;
    }
    
    public override string ToString()
    {
        return $"    BITCOIN\nName: {Name}\nBalance: {Balance}";
    }
}