namespace UnitTests.Helpers;

public static class PaymentCardHelper
{
    public static string GetPaymentCardAsString(string name, string cardNumber, int CVV)
    {
        var userInfo = UserInfoHelper.GetDefaultUserInfo();
        var clientName = userInfo.Name + " " + userInfo.LastName;
        var expirationDate = DateTime.Now.AddYears(4);
        var expirationDateString = $"{expirationDate.Month}/{expirationDate.Year}";
        
        return $"Name: {name}\nClient Name: {clientName}\nCard Number: {cardNumber}\nExpiration Date: {expirationDateString}\nCVV: {CVV}\n";
    }
}