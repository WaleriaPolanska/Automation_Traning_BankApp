namespace QA_Auto_BankApp.Models;

public class Product
{
    public string Name { get; }

    public float Price { get; }

    public Product(string name, float price)
    {
        Name = name;
        Price = price;
    }
}