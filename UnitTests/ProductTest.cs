using QA_Auto_BankApp.Models;

namespace UnitTests;

public class ProductTest
{
    [Fact]
    public void ProductNameSetIsSuccessfulIfNameIsValid()
    {
        const string expectedName = "boots";

        var product = new Product("boots", 100);
        var actualName = product.Name;

        Assert.Equal(expectedName, actualName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1")]
    public void ProductNameSetThrowsArgumentExceptionIfNameIsInvalid(string productName) =>
        Assert.Throws<ArgumentException>(() => new Product(productName, 100));

    [Fact]
    public void ProductPriceSetIsSuccessfulIfPriceIsValid()
    {
        const float expectedPrice = 10.5f;

        var product = new Product("boots", 10.5f);
        var actualPrice = product.Price;

        Assert.Equal(expectedPrice, actualPrice);
    }

    [Fact]
    public void ProductPriceSetThrowsArgumentExceptionIfPriceIsInvalid() =>
        Assert.Throws<ArgumentException>(() => new Product("asdf", -1));
}