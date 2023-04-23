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

    private static DateTime GetCardExpirationDate()
    {
        return DateTime.Now.AddYears(4);
    }

    public override string ToString()
    {
        return $"{_month}/{_year}";
    }
}