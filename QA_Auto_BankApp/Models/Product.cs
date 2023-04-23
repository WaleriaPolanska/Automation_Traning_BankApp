using QA_Auto_BankApp.Helpers;

namespace QA_Auto_BankApp.Models;

public class Product
{
    private string _name;
    private float _price;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 50)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Name"), nameof(value));
            }

            _name = value;
        }
    }
    
    public float Price
    {
        get { return _price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Price"), nameof(value));
            }

            _price = value;
        }
    }

    public Product(string name, float price)
    {
        Name = name;
        Price = price;
    }
}