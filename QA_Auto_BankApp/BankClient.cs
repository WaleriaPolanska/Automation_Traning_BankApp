namespace QA_Auto_BankApp;

public class BankClient
{
    private static List<string> _paymentMethodsTypesQueue =
        new() {"Cash", "CashbackCard", "DebitCard", "CreditCard", "BitCoin"};
    
    public UserInfo UserInfo { get; }

    private Dictionary<string, List<IPayment>> _paymentMethodsByName { get; }

    public BankClient(UserInfo userInfo)
    {
        UserInfo = userInfo;
        _paymentMethodsByName = new Dictionary<string, List<IPayment>>();
    }

    public void AddPaymentMethod(string paymentMethodType, IPayment paymentMethod)
    {
        if (!_paymentMethodsTypesQueue.Contains(paymentMethodType))
        {
            return;
        }
        
        if (!_paymentMethodsByName.ContainsKey(paymentMethodType))
        {
            _paymentMethodsByName.Add(paymentMethodType, new List<IPayment>());
        }
        
        _paymentMethodsByName[paymentMethodType].Add(paymentMethod);
    }

    public void TopUpPaymentMethod(string paymentMethodType, string name, float amount)
    {
        if (_paymentMethodsByName.ContainsKey(paymentMethodType))
        {
            var paymentMethods = _paymentMethodsByName[paymentMethodType];
            var paymentMethod = paymentMethods.FirstOrDefault(x => x.Name == name);

            paymentMethod?.TopUp(amount);
        }
    }

    public bool Pay(float sum)
    {
        foreach (var paymentMethodType in _paymentMethodsTypesQueue)
        {
            if (_paymentMethodsByName.ContainsKey(paymentMethodType))
            {
                var paymentMethods = _paymentMethodsByName[paymentMethodType];

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
        foreach (var (_, paymentMethods) in _paymentMethodsByName)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                Console.WriteLine($"{paymentMethod.Name} - {paymentMethod.GetBalance()}");   
            }
        }
    }
}