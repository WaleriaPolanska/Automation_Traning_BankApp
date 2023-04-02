namespace QA_Auto_BankApp;

public class CashbackCard : PaymentCard
{
    public float Interest { get; set; }
    public float Balance { get; set; }


    public CashbackCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo, float interest,
        float balance) : base(nameOfCard, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Balance = balance;
    }

    public override bool MakePayment(float sum)
    {
        if (Balance >= sum)
        {
            Balance = (Balance - sum) + sum * Interest / 100F;
            
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"    CASHBACK CARD\n{base.ToString()}Balance: {Balance}\nInterest: {Interest}%";
    }
}