namespace QA_Auto_BankApp;

public class CashbackCard : PaymentCard, IPayment
{
    public float Interest { get; set; }
    public float Balance { get; set; }


    public CashbackCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo, float interest,
        float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Balance = balance;
    }

    public bool MakePayment(float sum)
    {
        if (IPayment.IsCanPay(sum, Balance))
        {
            Balance = (Balance - sum) + sum * Interest / 100F;
            
            return true;
        }

        return false;
    }

    public void TopUp(float amount)
    {
        Balance += amount;
    }

    public float GetBalance()
    {
        return Balance;
    }

    public override string ToString()
    {
        return $"    CASHBACK CARD\n{base.ToString()}Balance: {Balance}\nInterest: {Interest}%";
    }
}