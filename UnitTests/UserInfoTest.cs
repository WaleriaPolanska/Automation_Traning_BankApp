using QA_Auto_BankApp.Models.BankClientInfo;

namespace UnitTests;

public class UserInfoTest
{
    [Fact]
    public void UserInfoNameSetIsSuccessfulIfNameIsValid()
    {
        const string expectedName = "Tom";
        
        var userInfo = new UserInfo("Tom", "Dwan", GetDefaultAddress(), "+33333333333");
        var actualName = userInfo.Name;
        
        Assert.Equal(expectedName, actualName);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1")]
    public void UserInfoNameSetThrowsArgumentExceptionIfNameIsInvalid(string name)
    {
        Assert.Throws<ArgumentException>(() => new UserInfo(name, "Harris", GetDefaultAddress(), "+33333333333"));
    }
    
    [Fact]
    public void UserInfoLastNameSetIsSuccessfulIfLastNameIsValid()
    {
        const string expectedLastName = "Simpson";
        
        var userInfo = new UserInfo("Tom", "Simpson", GetDefaultAddress(), "+33333333333");
        var actualLastName = userInfo.LastName;
        
        Assert.Equal(expectedLastName, actualLastName);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1")]
    public void UserInfoLastNameSetThrowsArgumentExceptionIfLastNameIsInvalid(string lastName)
    {
        Assert.Throws<ArgumentException>(() => new UserInfo("Tim", lastName, GetDefaultAddress(), "+33333333333"));
    }
    
    [Fact]
    public void UserInfoAddressSetIsSuccessfulIfAddressIsValid()
    {
        var expectedAddress = GetDefaultAddress();
        
        var userInfo = new UserInfo("Tom", "Dwan", GetDefaultAddress(), "+33333333333");
        var actualAddress = userInfo.Address;
        
        Assert.Equal(expectedAddress, actualAddress);
    }
    
    [Fact]
    public void UserInfoAddressSetThrowsArgumentExceptionIfAddressIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new UserInfo("Don", "Harris", null, "+33333333333"));
    }
    
    [Fact]
    public void UserInfoPhoneSetIsSuccessfulIfPhoneIsValid()
    {
        const string expectedPhone = "+77777777777";
        
        var userInfo = new UserInfo("Tom", "Dwan", GetDefaultAddress(), "+77777777777");
        var actualPhone = userInfo.Phone;
        
        Assert.Equal(expectedPhone, actualPhone);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("+4444444444")]
    [InlineData("+444444444444")]
    public void UserInfoPhoneSetThrowsArgumentExceptionIfPhoneIsInvalid(string phone)
    {
        Assert.Throws<ArgumentException>(() => new UserInfo("Todd", "Harris", GetDefaultAddress(), phone));
    }

    private static Address GetDefaultAddress()
    {
        return new Address("Polevaya", 2222, "Warsaw", "Poland", 222, 111);
    }
    
    [Fact]
    public void UserInfoToStringReturnsValidResult()
    {
        const string country = "Poland";
        const string city = "Warsaw";
        const int postcode = 123;
        const string street = "Les";
        const int buildingNumber = 22;
        const int apartment = 23;
        const string name = "Tom";
        const string lastName = "Simpson";
        const string phone = "+11111111111";
        
        var address = new Address(street, postcode, city, country, buildingNumber, apartment);
        var expectedToString = $"{name} {lastName}\n{address}\nPhone: {phone}";
        
        var userInfo = new UserInfo(name, lastName, address, phone);
        var actualToString = userInfo.ToString();

        Assert.Equal(expectedToString, actualToString);
    }
}