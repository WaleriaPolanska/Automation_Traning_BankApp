namespace QA_Auto_BankApp;

public class CreditCard : PaymentCard, IPayment
{
    public float CreditPercentage { get; }
    public float CreditLimit { get; set; }


    public CreditCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo,
        float creditPercentage,
        float creditLimit) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)
    {
        CreditPercentage = creditPercentage;
        CreditLimit = creditLimit;
    }

    public bool MakePayment(float sum)
    {
        float sumWithPercentage = sum + (sum * CreditPercentage) / 100F;
        
        if (IPayment.IsCanPay(sumWithPercentage, CreditLimit))
        {
            CreditLimit -= sumWithPercentage;

            return true;
        }

        return false;
    }

    public void TopUp(float amount)
    {
        CreditLimit += amount;
    }

    public float GetBalance()
    {
        return CreditLimit;
    }

    public override string ToString()
    {
        return $"    CREDIT CARD\n{base.ToString()}CreditLimit: {CreditLimit}\nCreditPercentage: {CreditPercentage}%";
    }
}