using System.Text;

using QA_Auto_BankApp.Enums;
using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;
using QA_Auto_BankApp.Models.PaymentMethods;

namespace QA_Auto_BankApp.Models;

public class BankClient
{
    private readonly UserInfo _userInfo;

    public UserInfo UserInfo
    {
        get => _userInfo;
        private init
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), ExceptionHelper.GetInvalidParameterMessage("UserInfo"));
            }

            _userInfo = value;
        }
    }

    public Dictionary<PaymentType, List<IPayment>> PaymentMethodsByName { get; }

    public BankClient(UserInfo userInfo)
    {
        UserInfo = userInfo;
        PaymentMethodsByName = new Dictionary<PaymentType, List<IPayment>>
        {
            {PaymentType.Cash, new List<IPayment>()},
            {PaymentType.CashbackCard, new List<IPayment>()},
            {PaymentType.DebitCard, new List<IPayment>()},
            {PaymentType.CreditCard, new List<IPayment>()},
            {PaymentType.BitCoin, new List<IPayment>()}
        };
    }

    public void AddPaymentMethod(IPayment paymentMethod)
    {
        PaymentType? paymentType = paymentMethod switch
        {
            Cash => PaymentType.Cash,
            CashbackCard => PaymentType.CashbackCard,
            DebitCard => PaymentType.DebitCard,
            CreditCard => PaymentType.CreditCard,
            BitCoin => PaymentType.BitCoin,
            _ => null
        };

        if (paymentType.HasValue)
        {
            PaymentMethodsByName[paymentType.Value].Add(paymentMethod);   
        }
    }

    public void TopUpPaymentMethod(PaymentType paymentType, string name, float amount)
    {
        var paymentMethods = PaymentMethodsByName[paymentType];
        var paymentMethod = paymentMethods.FirstOrDefault(x => x.Name == name);

        paymentMethod?.TopUp(amount);
    }

    public bool Pay(float sum)
    {
        foreach (var paymentMethodType in PaymentMethodsByName.Keys)
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

        return false;
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

    public override string ToString() => $"{UserInfo}\n{GetBalancesAsString()}\n";

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

    public override int GetHashCode() => HashCode.Combine(UserInfo.GetHashCode(), PaymentMethodsByName.GetHashCode());
}