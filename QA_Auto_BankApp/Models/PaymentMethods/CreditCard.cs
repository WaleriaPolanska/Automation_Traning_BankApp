using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class CreditCard : PaymentCard
{
    private float _creditPercentage;

    public float CreditPercentage
    {
        get => _creditPercentage;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("CreditPercentage"), nameof(value));
            }

            _creditPercentage = value;
        }
    }

    public CreditCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo,
        float creditPercentage, float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo, balance)
    {
        CreditPercentage = creditPercentage;
    }

    public override bool MakePayment(float sum)
    {
        var sumWithPercentage = sum + (sum * CreditPercentage) / 100F;
        
        if (PaymentHelper.IsCanPay(sumWithPercentage, Balance))
        {
            Balance -= sumWithPercentage;

            return true;
        }

        return false;
    }

    public override void TopUp(float amount) => Balance += amount;

    public override float GetBalance() => Balance;

    public override string ToString() => $"    CREDIT CARD\n{base.ToString()}CreditLimit: {Balance}\nCreditPercentage: {CreditPercentage}%";
}