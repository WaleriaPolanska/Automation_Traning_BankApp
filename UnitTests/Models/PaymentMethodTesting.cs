using QA_Auto_BankApp.Models.PaymentMethods;

namespace UnitTests.Models;

public class PaymentMethodTesting : PaymentMethod
{
    public PaymentMethodTesting(float balance) : base(balance)
    {
    }
}