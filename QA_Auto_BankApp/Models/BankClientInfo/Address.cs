using QA_Auto_BankApp.Helpers;

namespace QA_Auto_BankApp.Models.BankClientInfo;

public class Address
{
    private string _street;
    private int _postcode;
    private string _city;
    private string _country;
    private int _buildingNumber;
    private int _apartment;

    public string Street
    {
        get => _street;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 50)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Street"), nameof(value));
            }

            _street = value;
        }
    }

    public int Postcode
    {
        get => _postcode;
        set
        {
            if (value <= 0 || value.ToString().Length > 5)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Postcode"), nameof(value));
            }

            _postcode = value;
        }
    }

    public string City
    {
        get => _city;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 20)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("City"), nameof(value));
            }

            _city = value;
        }
    }

    public string Country
    {
        get => _country;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 20)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Country"), nameof(value));
            }

            _country = value;
        }
    }
    
    public int BuildingNumber
    {
        get => _buildingNumber;
        set
        {
            if (value <= 0 || value.ToString().Length > 5)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Building number"), nameof(value));
            }

            _buildingNumber = value;
        }
    }

    public int Apartment
    {
        get => _apartment;
        set
        {
            if (value <= 0 || value.ToString().Length > 5)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Apartment"), nameof(value));
            }

            _apartment = value;
        }
    }

    public Address(string street, int postcode, string city, string country, int buildingNumber, int apartment)
    {
        Country = country;
        Postcode = postcode;
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
        Apartment = apartment;
    }

    public override string ToString() => $"Country: {Country} {Postcode}\nCity: {City}\nStreet: {Street}, {BuildingNumber}/{Apartment}";

    public override bool Equals(object? obj)
    {
        if (obj is Address address)
        {
            return Country == address.Country && Postcode == address.Postcode && City == address.City 
                   && Street == address.Street && BuildingNumber == address.BuildingNumber 
                   && Apartment == address.Apartment;
        }
        
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Country, Postcode, City, Street, BuildingNumber, Apartment);
}