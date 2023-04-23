using QA_Auto_BankApp.Helpers;
using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public abstract class PaymentCard : IPayment
{
    private string _name;
    private string _cardNumber;
    private readonly ExpirationDate _expirationDate;
    private string _clientName;
    private int _cvv;
    private UserInfo _userInfo;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 20)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Name"), nameof(value));
            }

            _name = value;
        }
    }

    public string CardNumber
    {
        get { return _cardNumber; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length != 16)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("CardNumber"), nameof(value));
            }

            _cardNumber = value;
        }
    }

    public int CVV
    {
        get { return _cvv; }
        set
        {
            if (value.ToString().Length != 3)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("CVV"), nameof(value));
            }

            _cvv = value;
        }
    }

    public UserInfo UserInfo
    {
        get { return _userInfo; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), ExceptionHelper.GetInvalidParameterMessage("Expiration date"));
            }

            _userInfo = value;
        }
    }

    public PaymentCard(string nameOfPaymentMethod, string numberOfCard, int codeCVV, UserInfo userInfo)
    {
        Name = nameOfPaymentMethod;
        CardNumber = numberOfCard;
        CVV = codeCVV;
        _expirationDate = new ExpirationDate();
        UserInfo = userInfo;
        _clientName = userInfo.Name + " " + userInfo.LastName;
    }

    public abstract bool MakePayment(float amount);

    public abstract void TopUp(float amount);

    public abstract float GetBalance();

    public override string ToString()
    {
        return $"Name: {Name}\nClient Name: {_clientName}\nCard Number: {CardNumber}\nExpiration Date: {_expirationDate}\nCVV: {CVV}\n";
    }

    public void GetCardInfo(string cardInfo)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Payment Metod: {Name}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(cardInfo);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("User info:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{UserInfo}\n\n");
    }
}