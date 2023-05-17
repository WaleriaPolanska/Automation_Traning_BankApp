using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class CashbackCard : PaymentCard
{
    private float _interest;

    public float Interest
    {
        get => _interest;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Interest"), nameof(value));
            }

            _interest = value;
        }
    }

    public CashbackCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo, float
        interest, float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo, balance)
    {
        Interest = interest;
    }

    public override bool MakePayment(float sum)
    {
        if (PaymentHelper.IsCanPay(sum, Balance))
        {
            Balance = (Balance - sum) + sum * Interest / 100F;

            return true;
        }

        return false;
    }

    public override void TopUp(float amount) => Balance += amount;

    public override float GetBalance() => Balance;

    public override string ToString() => $"    CASHBACK CARD\n{base.ToString()}Balance: {Balance}\nInterest: {Interest}%";
}