namespace QA_Auto_BankApp;

public class BankClientAdressComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        if (x is null || y is null)
        {
            throw new ArgumentNullException();
        }

        var countryCompareResult = string.Compare(x.UserInfo.Address.Country, y.UserInfo.Address.Country,
            StringComparison.Ordinal);
        
        if (countryCompareResult != 0)
        {
            return countryCompareResult;
        }

        var cityCompareResult =
            string.Compare(x.UserInfo.Address.City, y.UserInfo.Address.City, StringComparison.Ordinal);
        
        if (cityCompareResult != 0)
        {
            return cityCompareResult;
        }
        
        var postcodeCompareResult = x.UserInfo.Address.Postcode.CompareTo(y.UserInfo.Address.Postcode);
        
        if (postcodeCompareResult != 0)
        {
            return postcodeCompareResult;
        }

        var streetCompareResult = string.Compare(x.UserInfo.Address.Street, y.UserInfo.Address.Street,
            StringComparison.Ordinal);
        
        if (streetCompareResult != 0)
        {
            return streetCompareResult;
        }

        var buildingNumberCompareResult =
            x.UserInfo.Address.BuildingNumber.CompareTo(y.UserInfo.Address.BuildingNumber);
        
        if (buildingNumberCompareResult != 0)
        {
            return buildingNumberCompareResult;
        }

        var apartmentCompareResult = x.UserInfo.Address.Apartment.CompareTo(y.UserInfo.Address.Apartment);
        
        return apartmentCompareResult;
    }
}