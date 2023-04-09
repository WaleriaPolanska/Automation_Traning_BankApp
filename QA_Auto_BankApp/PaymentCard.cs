namespace QA_Auto_BankApp;

public abstract class PaymentCard
{
    public string PaymentMethodName { get; }
    public long CardNumber { get; }
    public ExpirationDate ExpirationDate { get; }
    public string ClientName { get; }
    public int CVV { get; }

    public static UserInfo UserInfo { get; set; }

    public PaymentCard(string nameOfPaymentMethod, long numberOfCard, int codeCVV, UserInfo userInfo)
    {
        PaymentMethodName = nameOfPaymentMethod;
        CardNumber = numberOfCard;
        ClientName = userInfo.Name + " " + userInfo.LastName;
        CVV = codeCVV;
        ExpirationDate = new ExpirationDate();
        UserInfo = userInfo;
    }
    public override string ToString()
    {
        return $"Client Name: {ClientName}\nCard Number: {CardNumber}\nExpiration Date: {ExpirationDate}\nCVV: {CVV}\n";
    }

    public void GetCardInfo(string cardInfo)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Payment Metod: {PaymentMethodName}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(cardInfo);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("User info:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{UserInfo}\n\n");
    }
}