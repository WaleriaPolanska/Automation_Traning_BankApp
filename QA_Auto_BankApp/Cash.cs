namespace QA_Auto_BankApp;

public class Cash : IPayment
{
    public string Name { get; }
    public float Amount { get; set; }

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
}