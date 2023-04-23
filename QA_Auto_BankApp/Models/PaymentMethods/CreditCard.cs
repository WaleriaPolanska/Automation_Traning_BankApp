using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class CreditCard : PaymentCard
{
    private float _creditPercentage;
    private float _creditLimit;

    public float CreditPercentage
    {
        get { return _creditPercentage; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("CreditPercentage"), nameof(value));
            }

            _creditPercentage = value;
        }
    }

    public float CreditLimit
    {
        get { return _creditLimit; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("CreditLimit"), nameof(value));
            }

            _creditLimit = value;
        }
    }
    
    public CreditCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo,
        float creditPercentage,
        float creditLimit) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)
    {
        CreditPercentage = creditPercentage;
        CreditLimit = creditLimit;
    }

    public override bool MakePayment(float sum)
    {
        float sumWithPercentage = sum + (sum * CreditPercentage) / 100F;
        
        if (IPayment.IsCanPay(sumWithPercentage, CreditLimit))
        {
            CreditLimit -= sumWithPercentage;

            return true;
        }

        return false;
    }

    public override void TopUp(float amount)
    {
        CreditLimit += amount;
    }

    public override float GetBalance()
    {
        return CreditLimit;
    }

    public override string ToString()
    {
        return $"    CREDIT CARD\n{base.ToString()}CreditLimit: {CreditLimit}\nCreditPercentage: {CreditPercentage}%";
    }
}