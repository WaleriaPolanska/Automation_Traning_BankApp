using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public class DebitCard : PaymentCard
{
    private float _interest;
    private float _debit;

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

    public float Debit
    {
        get { return _debit; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Debit"), nameof(value));
            }

            _debit = value;
        }
    }

    public DebitCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo, float interest,
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