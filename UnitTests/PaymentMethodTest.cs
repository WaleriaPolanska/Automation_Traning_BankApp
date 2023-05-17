using UnitTests.Models;

namespace UnitTests;

public class PaymentMethodTest
{
    [Fact]
    public void PaymentMethodBalanceSetIsSuccessfulIfBalanceIsValid()
    {
        const float expectedBalance = 0.8f;

        var paymentMethod = new PaymentMethodTesting(0.8f);
        var actualBalance = paymentMethod.Balance;

        Assert.Equal(expectedBalance, actualBalance);
    }

    [Fact]
    public void PaymentMethodBalanceSetThrowsArgumentExceptionIfBalanceIsInvalid() =>
        Assert.Throws<ArgumentException>(() => new PaymentMethodTesting(-3f));
}