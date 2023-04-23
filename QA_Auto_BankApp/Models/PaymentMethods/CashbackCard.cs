using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class CashbackCard : PaymentCard
{
    private float _interest;
    private float _balance;

    public float Interest
    {
        get { return _interest; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Interest"), nameof(value));
            }

            _interest = value;
        }
    }

    public float Balance
    {
        get { return _balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Balance"), nameof(value));
            }

            _balance = value;
        }
    }
    
    public CashbackCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo, float
        interest,
        float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo)

    {
        Interest = interest;
        Balance = balance;
    }

    public override bool MakePayment(float sum)
    {
        if (IPayment.IsCanPay(sum, Balance))
        {
            Balance = (Balance - sum) + sum * Interest / 100F;

            return true;
        }

        return false;
    }

    public override void TopUp(float amount)
    {
        Balance += amount;
    }

    public override float GetBalance()
    {
        return Balance;
    }

    public override string ToString()
    {
        return $"    CASHBACK CARD\n{base.ToString()}Balance: {Balance}\nInterest: {Interest}%";
    }
}