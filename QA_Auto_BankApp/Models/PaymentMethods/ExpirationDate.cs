namespace QA_Auto_BankApp.Models.PaymentMethods;

public class ExpirationDate
{
    private readonly int _month;
    private readonly int _year;
    
    public ExpirationDate()
    {
        var expirationDate = GetCardExpirationDate();
        
        _month = expirationDate.Month;
        _year = expirationDate.Year;
    }

    private static DateTime GetCardExpirationDate() => DateTime.Now.AddYears(4);

    public override string ToString() => $"{_month}/{_year}";
}