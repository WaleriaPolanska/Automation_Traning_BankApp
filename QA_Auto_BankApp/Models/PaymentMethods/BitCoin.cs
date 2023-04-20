using QA_Auto_BankApp.Interfaces;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class BitCoin : IPayment
{
    public string Name { get; }
    public float Balance { get; set; }

    public float ExchangeRate { get; set; }

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
        return Balance;
    }
}