namespace QA_Auto_BankApp;

public class BitCoin : IPayment
{
    public string PaymentMethodName { get; }
    public float Balance { get; set; }

    public float ExchangeRate { get; set; }

    public BitCoin(string paymentMethodName, float exchangeRate, float bitCoinAmount)
    {
        PaymentMethodName = paymentMethodName;
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