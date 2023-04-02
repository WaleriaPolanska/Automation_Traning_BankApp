namespace QA_Auto_BankApp;

public class Wallet
{
    public List<PaymentCard> PaymentCards { get; }

    public Wallet(List<PaymentCard> paymentCards)
    {
        PaymentCards = paymentCards;
    }

    public bool Pay(float sum)
    {
        foreach (var paymentCard in PaymentCards)
        {
            if (paymentCard is CashbackCard cashbackCard && cashbackCard.MakePayment(sum)
                || paymentCard is DebitCard debitCard && debitCard.MakePayment(sum)
                || paymentCard is CreditCard creditCard && creditCard.MakePayment(sum))
            {
                return true;
            }
        }
        
        return false;
    }
}