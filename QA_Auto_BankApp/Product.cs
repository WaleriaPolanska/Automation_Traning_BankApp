namespace QA_Auto_BankApp;

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