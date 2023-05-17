namespace QA_Auto_BankApp.Helpers;

public static class PaymentHelper
{
    public static bool IsCanPay(float amount, float availableFunds) => availableFunds >= amount;
}