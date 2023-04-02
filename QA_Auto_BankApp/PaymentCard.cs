namespace QA_Auto_BankApp;

public class PaymentCard
{
    public string CardName { get; }
    public long CardNumber { get; }
    public ExpirationDate ExpirationDate { get; }
    public string ClientName { get; }
    public int CVV { get; }

    public UserInfo UserInfo { get; }

    public PaymentCard(string nameOfCard, long numberOfCard, int codeCVV, UserInfo userInfo)
    {
        CardName = nameOfCard;
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
        Console.WriteLine($"Card Name: {CardName}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(cardInfo);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("User info:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{UserInfo}\n\n");
    }
}