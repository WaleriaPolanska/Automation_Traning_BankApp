using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class DebitCard : PaymentCard
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

    public DebitCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo, float interest,
        float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo, balance)
    {
        Interest = interest;
    }

    public override bool MakePayment(float sum)
    {
        if (PaymentHelper.IsCanPay(sum, Balance))
        {
            Balance -= sum;

            return true;
        }

        return false;
    }

    public override void TopUp(float amount) => Balance += amount + amount * Interest / 100;

    public override float GetBalance() => Balance;

    public override string ToString() => $"    DEBIT CARD\n{base.ToString()}Debit: {Balance}\nInterest: {Interest}%";
}