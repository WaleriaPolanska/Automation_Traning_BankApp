namespace QA_Auto_BankApp;

public class UserInfo
{
    public string Name { get; }
    public string LastName { get; }
    public Address Address { get; }
    public string Phone { get; }

    public UserInfo(string username, string userLastName, Address userAddress, string userPhone)
    {
        Name = username;
        LastName = userLastName;
        Address = userAddress;
        Phone = userPhone;
    }

    public override string ToString()
    {
        return $"{Name} {LastName}\n{Address}\nPhone: {Phone}";
    }
}