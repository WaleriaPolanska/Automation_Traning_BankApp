using QA_Auto_BankApp.Helpers;

namespace QA_Auto_BankApp.Models.BankClientInfo;

public class UserInfo
{
    private string _name;
    private string _lastName;
    private Address _address;
    private string _phone;
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 50)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Name"), nameof(value));
            }

            _name = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 50)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Lastname"), nameof(value));
            }

            _lastName = value;
        }
    }

    public Address Address
    {
        get => _address;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), ExceptionHelper.GetInvalidParameterMessage("Address"));
            }

            _address = value;
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length != 12)
            {
                throw new ArgumentException(ExceptionHelper.GetInvalidParameterMessage("Phone"), nameof(value));
            }

            _phone = value;
        }
    }

    public UserInfo(string username, string userLastName, Address userAddress, string userPhone)
    {
        Name = username;
        LastName = userLastName;
        Address = userAddress;
        Phone = userPhone;
    }

    public override string ToString() => $"{Name} {LastName}\n{Address}\nPhone: {Phone}";

    public override bool Equals(object? obj)
    {
        if (obj is UserInfo userInfo)
        {
            return Name == userInfo.Name && LastName == userInfo.LastName && Phone == userInfo.Phone 
                   && Address.Equals(userInfo.Address);
        }
        
        return false;
    }
    
    public override int GetHashCode() => HashCode.Combine(Name, LastName, Phone, Address.GetHashCode());
}