namespace QA_Auto_BankApp;

public class DebitCard : PaymentCard
{
    public double Interest { get; set; }
    public float Debit { get; set; }


    public DebitCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo, double interest,
        float debit) : base(nameOfCard, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Debit = debit;
    }

    public override bool MakePayment(float sum)
    {
        if (Debit >= sum)
        {
            Debit -= sum;
            
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"    DEBIT CARD\n{base.ToString()}Debit: {Debit}\nInterest: {Interest}%";
    }
}