namespace QA_Auto_BankApp;

public class DebitCard : PaymentCard
{
    public double Interest { get; set; }
    public long Debit { get; set; }


    public DebitCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo, double interest,
        long debit) : base(nameOfCard, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Debit = debit;
    }

    public override string ToString()
    {
        return $"    DEBIT CARD\n{base.ToString()}Debit: {Debit}\nInterest: {Interest}%";
    }
}