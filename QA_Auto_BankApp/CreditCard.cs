namespace QA_Auto_BankApp;

public class CreditCard : PaymentCard
{
    public double CreditPercentage { get; set; }
    public long CreditLimit { get; set; }


    public CreditCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo, double creditPercentage,
        long creditLimit) : base(nameOfCard, numberOfCard, codeCVV, userInfo)
    {
        CreditPercentage = creditPercentage;
        CreditLimit = creditLimit;
    }

    public override string ToString()
    {
        return $"    CREDIT CARD\n{base.ToString()}CreditLimit: {CreditLimit}\nCreditPercentage: {CreditPercentage}%";
    }
}