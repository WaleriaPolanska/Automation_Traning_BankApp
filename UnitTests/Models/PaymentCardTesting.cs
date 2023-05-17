using QA_Auto_BankApp.Models.BankClientInfo;
using QA_Auto_BankApp.Models.PaymentMethods;

namespace UnitTests.Models;

public class PaymentCardTesting : PaymentCard
{
    public PaymentCardTesting(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo, 
        float balance) : base(nameOfPaymentMethod, numberOfCard, codeCVV, userInfo, balance)
    {
    }

    public override bool MakePayment(float amount) => throw new NotImplementedException();

    public override void TopUp(float amount) => throw new NotImplementedException();

    public override float GetBalance() => throw new NotImplementedException();
}