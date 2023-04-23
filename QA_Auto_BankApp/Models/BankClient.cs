using System.Text;
using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models;

public class BankClient
{
    private static List<string> _paymentMethodsTypesQueue =
        new() {"Cash", "CashbackCard", "DebitCard", "CreditCard", "BitCoin"};

    private UserInfo _userInfo;

    public UserInfo UserInfo
    {
        get { return _userInfo; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), ExceptionHelper.GetInvalidParameterMessage("UserInfo"));
            }

            _userInfo = value;
        }
    }

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

    private string GetBalancesAsString()
    {
        var sb = new StringBuilder();

        foreach (var key in PaymentMethodsByName.Keys)
        {
            foreach (var method in PaymentMethodsByName[key])
            {
                sb.Append($"{method}\n");
            }
        }
        
        return sb.ToString();
    }

    public override string ToString()
    {
        return $"{UserInfo}\n{GetBalancesAsString()}\n";
    }

    public override bool Equals(object? obj)
    {
        if (obj is BankClient client)
        {
            return UserInfo.Name == client.UserInfo.Name 
                   && UserInfo.LastName == client.UserInfo.LastName && UserInfo.Address.Equals(client.UserInfo.Address) 
                   && Math.Abs(PaymentMethodsByName.Keys.Sum(key => 
                       PaymentMethodsByName[key].Sum(paymentMethod => 
                           paymentMethod.GetBalance())) - client.PaymentMethodsByName.Keys.Sum(key => 
                       client.PaymentMethodsByName[key].Sum(paymentMethod => paymentMethod.GetBalance()))) < 0.01f;
        }
        
        return false;
    }

    public override int GetHashCode()
    {
        return UserInfo.GetHashCode();
    }
}