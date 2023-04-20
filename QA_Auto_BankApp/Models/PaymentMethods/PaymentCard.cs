using QA_Auto_BankApp.Interfaces;
using QA_Auto_BankApp.Models.BankClientInfo;

namespace QA_Auto_BankApp.Models.PaymentMethods;

public abstract class PaymentCard : IPayment
{
    public string Name { get; }
    public long CardNumber { get; }
    public ExpirationDate ExpirationDate { get; }
    public string ClientName { get; }
    public int CVV { get; }

    public static UserInfo UserInfo { get; set; }

    public PaymentCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo)
    {
        Name = nameOfPaymentMethod;
        CardNumber = numberOfCard;
        ClientName = userInfo.Name + " " + userInfo.LastName;
        CVV = codeCVV;
        ExpirationDate = new ExpirationDate();
        UserInfo = userInfo;
    }

    public abstract bool MakePayment(float amount);

    public abstract void TopUp(float amount);

    public abstract float GetBalance();
    
    public override string ToString()
    {
        return $"Client Name: {ClientName}\nCard Number: {CardNumber}\nExpiration Date: {ExpirationDate}\nCVV: {CVV}\n";
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