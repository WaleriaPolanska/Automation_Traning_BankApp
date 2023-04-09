namespace QA_Auto_BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserInfo userInfo = new UserInfo("Jan", "Kowalski", new Address("Lesnaya",
                11100, "Warsaw", "Poland", 49, 209), "+48555555555");
            List<Product> products = new List<Product>
            {
                new Product("hat", 155F),
                new Product("sapogi", 2000F),
                new Product("bag", 300F),
                new Product("acvarium", 2100F),
                new Product("sponge", 4600F)
            };

            var paymentMethod1 = new DebitCard("DebitCard1", 0000000000000000,
                123, userInfo, 2.4F, 200);
            var paymentMethod2 = new DebitCard("DebitCard2", 1111111111111111,
                123, userInfo, 5.7F, 290);
            var paymentMethod3 = new CashbackCard("CashbackCard1", 2222222222222222,
                123, userInfo, 3.5F, 900);
            var paymentMethod4 = new CreditCard("CreditCard1", 3333333333333333,
                123, userInfo, 7.0F, 5000);
            var paymentMethod5 = new CreditCard("CreditCard2", 4444444444444444,
                123, userInfo, 5.8F, 850);
            var paymentMethod6 = new Cash("Cash", 100);
            var paymentMethod7 = new BitCoin("BTC", 20000, 0.5f);

            List<IPayment> paymentMethods = new List<IPayment> {paymentMethod1, paymentMethod2, paymentMethod3, 
                paymentMethod4, paymentMethod5, paymentMethod6, paymentMethod7};
            BankClient bankClient = new BankClient(userInfo, paymentMethods);

            foreach (var product in products)
            {
                bankClient.Pay(product.Price);
            }

            bankClient.OutputBalances();
        }
    }
}