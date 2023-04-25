using QA_Auto_BankApp.Models.BankClientInfo;

namespace UnitTests;

public class AddressTest
{
    [Fact]
    public void AddressStreetSetIsSuccessfulIfStreetIsValid()
    {
        const string expectedStreet = "Polevaya";
        
        var address = new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111);
        var addressStreet = address.Street;
        
        Assert.Equal(expectedStreet, addressStreet);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1")]
    public void AddressStreetSetThrowsArgumentExceptionIfStreetIsInvalid(string street)
    {
        Assert.Throws<ArgumentException>(() => new Address(street, 2222, "Warsaw", "Poland", 222, 111));
    }
    
    [Fact]
    public void AddressPostcodeSetIsSuccessfulIfPostcodeIsValid()
    {
        const int expectedPostcode = 15468;
        
        var address = new Address("Polevaya", 15468, "Warsaw", "Poland", 222, 111);
        var addressPostcode = address.Postcode;
        
        Assert.Equal(expectedPostcode, addressPostcode);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(100000)]
    public void AddressPostcodeSetThrowsArgumentExceptionIfPostcodeIsInvalid(int postcode)
    {
        Assert.Throws<ArgumentException>(() => new Address("Les", postcode, "Warsaw", "Poland", 222, 111));
    }
    
    [Fact]
    public void AddressCitySetIsSuccessfulIfCityIsValid()
    {
        const string expectedCity = "Warsaw";
        
        var address = new Address("Polevaya", 15468, "Warsaw", "Poland", 222, 111);
        var addressCity = address.City;
        
        Assert.Equal(expectedCity, addressCity);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaa1")]
    public void AddressCitySetThrowsArgumentExceptionIfCityIsInvalid(string city)
    {
        Assert.Throws<ArgumentException>(() => new Address("Les", 123, city, "Poland", 222, 111));
    }
    
    [Fact]
    public void AddressCountrySetIsSuccessfulIfCountryIsValid()
    {
        const string expectedCountry = "Poland";
        
        var address = new Address("Polevaya", 15468, "Warsaw", "Poland", 222, 111);
        var addressCountry = address.Country;
        
        Assert.Equal(expectedCountry, addressCountry);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaa1")]
    public void AddressCountrySetThrowsArgumentExceptionIfCountryIsInvalid(string country)
    {
        Assert.Throws<ArgumentException>(() => new Address("Les", 123, "Warsaw", country, 222, 111));
    }
    
    [Fact]
    public void AddressBuildingNumberSetIsSuccessfulIfBuildingNumberIsValid()
    {
        const int expectedBuildingNumber = 222;
        
        var address = new Address("Polevaya", 15468, "Warsaw", "Poland", 222, 111);
        var addressBuildingNumber = address.BuildingNumber;
        
        Assert.Equal(expectedBuildingNumber, addressBuildingNumber);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(100000)]
    public void AddressBuildingNumberSetThrowsArgumentExceptionIfBuildingNumberIsInvalid(int buildingNumber)
    {
        Assert.Throws<ArgumentException>(() => new Address("Les", 123, "Warsaw", "Poland", buildingNumber, 111));
    }
    
    [Fact]
    public void AddressApartmentSetIsSuccessfulIfApartmentIsValid()
    {
        const int expectedApartment = 111;
        
        var address = new Address("Polevaya", 15468, "Warsaw", "Poland", 222, 111);
        var addressApartment = address.Apartment;
        
        Assert.Equal(expectedApartment, addressApartment);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(100000)]
    public void AddressApartmentSetThrowsArgumentExceptionIfApartmentIsInvalid(int apartment)
    {
        Assert.Throws<ArgumentException>(() => new Address("Les", 123, "Warsaw", "Poland", 445, apartment));
    }
    
    [Fact]
    public void AddressToStringReturnsValidResult()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;
        
        var expectedToString = $"Country: {country} {postcode}\nCity: {city}\nStreet: {street}, {buildingNumber}/{apartment}";

        var address = new Address(street, postcode, city, country, buildingNumber, apartment);
        var actualToString = address.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
    
    [Fact]
    public void AddressesEqualityIsValid()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, city, country, buildingNumber, apartment);
        var address2 = new Address(street, postcode, city, country, buildingNumber, apartment);

        Assert.True(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfStreetsAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, city, country, buildingNumber, apartment);
        var address2 = new Address("Doroga", postcode, city, country, buildingNumber, apartment);

        Assert.False(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfPostCodesAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, 456, city, country, buildingNumber, apartment);
        var address2 = new Address(street, postcode, city, country, buildingNumber, apartment);

        Assert.False(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfCitiesAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, "Wroclaw", country, buildingNumber, apartment);
        var address2 = new Address(street, postcode, city, country, buildingNumber, apartment);

        Assert.False(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfCountriesAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, city, country, buildingNumber, apartment);
        var address2 = new Address(street, postcode, city, "Italy", buildingNumber, apartment);

        Assert.False(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfBuildingNumbersAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, city, country, 100, apartment);
        var address2 = new Address(street, postcode, city, country, buildingNumber, apartment);

        Assert.False(address1.Equals(address2));
    }
    
    [Fact]
    public void AddressesEqualityIsNotValidIfApartmentsAreNotEqual()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;

        var address1 = new Address(street, postcode, city, country, buildingNumber, apartment);
        var address2 = new Address(street, postcode, city, country, buildingNumber, 100);

        Assert.False(address1.Equals(address2));
    }
}