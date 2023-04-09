namespace QA_Auto_BankApp;

public class BankClient
{
    public UserInfo UserInfo { get; }
    
    public List<IPayment> PaymentMethods { get; }

    public BankClient(UserInfo userInfo, List<IPayment> paymentMethods)
    {
        UserInfo = userInfo;
        PaymentMethods = paymentMethods;
    }

    public bool Pay(float sum)
    {
        foreach (var paymentMethod in PaymentMethods)
        {
            if (paymentMethod is Cash cash && cash.MakePayment(sum)
                ||paymentMethod is CashbackCard cashbackCard && cashbackCard.MakePayment(sum)
                || paymentMethod is DebitCard debitCard && debitCard.MakePayment(sum)
                || paymentMethod is CreditCard creditCard && creditCard.MakePayment(sum)
                || paymentMethod is BitCoin bitCoin && bitCoin.MakePayment(sum))
            {
                return true;
            }
        }
        
        return false;
    }

    public void OutputBalances()
    {
        foreach (var paymentMethod in PaymentMethods)
        {
            Console.WriteLine($"{paymentMethod.PaymentMethodName} - {paymentMethod.GetBalance()}");
        }
    }
}