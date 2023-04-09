namespace QA_Auto_BankApp;

public interface IPayment
{
    public string PaymentMethodName { get; }
    public bool MakePayment(float amount);

    public void TopUp(float amount);

    public float GetBalance();
    
    public static bool IsCanPay(float amount, float availableFunds)
    {
        return availableFunds >= amount;
    }
}