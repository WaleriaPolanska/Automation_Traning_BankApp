namespace QA_Auto_BankApp;

public class BankClient
{
    private static List<string> _paymentMethodsTypesQueue =
        new() {"Cash", "CashbackCard", "DebitCard", "CreditCard", "BitCoin"};
    
    public UserInfo UserInfo { get; }

    public Dictionary<string, List<IPayment>> PaymentMethodsByName { get; }

    public BankClient(UserInfo userInfo)
    {
        UserInfo = userInfo;
        PaymentMethodsByName = new Dictionary<string, List<IPayment>>();
    }

    public void AddPaymentMethod(string paymentMethodType, IPayment paymentMethod)
    {
        if (!_paymentMethodsTypesQueue.Contains(paymentMethodType))
        {
            return;
        }
        
        if (!PaymentMethodsByName.ContainsKey(paymentMethodType))
        {
            PaymentMethodsByName.Add(paymentMethodType, new List<IPayment>());
        }
        
        PaymentMethodsByName[paymentMethodType].Add(paymentMethod);
    }

    public void TopUpPaymentMethod(string paymentMethodType, string name, float amount)
    {
        if (PaymentMethodsByName.ContainsKey(paymentMethodType))
        {
            var paymentMethods = PaymentMethodsByName[paymentMethodType];
            var paymentMethod = paymentMethods.FirstOrDefault(x => x.Name == name);

            paymentMethod?.TopUp(amount);
        }
    }

    public bool Pay(float sum)
    {
        foreach (var paymentMethodType in _paymentMethodsTypesQueue)
        {
            if (PaymentMethodsByName.ContainsKey(paymentMethodType))
            {
                var paymentMethods = PaymentMethodsByName[paymentMethodType];

                foreach (var paymentMethod in paymentMethods)
                {
                    if (paymentMethod.MakePayment(sum))
                    {
                        return true;
                    }
                }   
            }
        }

        return false;
    }

    public void OutputBalances()
    {
        foreach (var (_, paymentMethods) in PaymentMethodsByName)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                Console.WriteLine($"{paymentMethod.Name} - {paymentMethod.GetBalance()}");   
            }
        }
    }

    public override string ToString()
    {
        return $"{UserInfo.Name} {UserInfo.LastName}";
    }
}