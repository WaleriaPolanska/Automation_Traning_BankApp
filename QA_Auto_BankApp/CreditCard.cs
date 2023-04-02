namespace QA_Auto_BankApp;

public class CreditCard : PaymentCard
{
    public float CreditPercentage { get; set; }
    public float CreditLimit { get; set; }


    public CreditCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo, float creditPercentage,
        float creditLimit) : base(nameOfCard, numberOfCard, codeCVV, userInfo)
    {
        CreditPercentage = creditPercentage;
        CreditLimit = creditLimit;
    }

    public override bool MakePayment(float sum)
    {
        float sumWithPercentage = sum + (sum * CreditPercentage) / 100F;
        
        if (CreditLimit >= sumWithPercentage)
        {
            CreditLimit -= sumWithPercentage;

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"    CREDIT CARD\n{base.ToString()}CreditLimit: {CreditLimit}\nCreditPercentage: {CreditPercentage}%";
    }
}