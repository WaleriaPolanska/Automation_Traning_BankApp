namespace QA_Auto_BankApp;

public class DebitCard : PaymentCard, IPayment
{
    public float Interest { get; set; }
    public float Debit { get; set; }
    
    private IPayment _paymentImplementation;

    public DebitCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo, float interest,
        float debit) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Debit = debit;
    }

    public bool MakePayment(float sum)
    {
        if (IPayment.IsCanPay(sum, Debit))
        {
            Debit -= sum;
            
            return true;
        }

        return false;
    }
    
    public void TopUp(float amount)
    {
        Debit += amount + amount * Interest / 100;
    }

    public float GetBalance()
    {
        return Debit;
    }

    public override string ToString()
    {
        return $"    DEBIT CARD\n{base.ToString()}Debit: {Debit}\nInterest: {Interest}%";
    }
}