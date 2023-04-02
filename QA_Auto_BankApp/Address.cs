namespace QA_Auto_BankApp;

public class Address
{
    public string Street { get; }
    public int Postcode { get; }
    public string City { get; }
    public string Country { get; }

    public int BuildingNumber { get; set; }

    public int Apartment { get; set; }

    public Address(string street, int postcode, string city, string country, int buildingNumber, int apartment)
    {
        Country = country;
        Postcode = postcode;
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
        Apartment = apartment;
    }

    public override string ToString()
    {
        return $"Country: {Country} {Postcode}\nCity: {City}\nStreet: {Street}, {BuildingNumber}/{Apartment}";
    }
}