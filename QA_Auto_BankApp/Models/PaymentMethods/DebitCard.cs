using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class DebitCard : PaymentCard
{
    public float Interest { get; set; }
    public float Debit { get; set; }

    public DebitCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo, float interest,
        float debit) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Debit = debit;
    }

    public override bool MakePayment(float sum)
    {
        if (IPayment.IsCanPay(sum, Debit))
        {
            Debit -= sum;
            
            return true;
        }

        return false;
    }
    
    public override void TopUp(float amount)
    {
        Debit += amount + amount * Interest / 100;
    }

    public override float GetBalance()
    {
        return Debit;
    }

    public override string ToString()
    {
        return $"    DEBIT CARD\n{base.ToString()}Debit: {Debit}\nInterest: {Interest}%";
    }
}