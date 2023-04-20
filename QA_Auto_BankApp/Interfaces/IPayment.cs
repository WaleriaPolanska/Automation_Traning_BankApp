namespace QA_Auto_BankApp.Interfaces;

public interface IPayment
{
    public string Name { get; }
    
    public bool MakePayment(float amount);

    public void TopUp(float amount);

    public float GetBalance();
    
    public static bool IsCanPay(float amount, float availableFunds)
    {
        return availableFunds >= amount;
    }
}