namespace QA_Auto_BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserInfo userInfo = new UserInfo("Jan", "Kowalski", new Address("Lesnaya", 
                    11100, "Warsaw", "Poland", 49, 209), "+48555555555");
            Product boots = new Product("Sapogi", 2000F);

            var card1 = new DebitCard("card1", 0000000000000000,
                123, userInfo, 2.4, 200);
            var card2 = new DebitCard("card2", 1111111111111111,
                123, userInfo, 5.7, 290);
            var card3 = new CashbackCard("card3", 2222222222222222,
                123, userInfo, 3.5F, 900);
            var card4 = new CreditCard("card4", 3333333333333333,
                123, userInfo, 7.0F, 5000);
            var card5 = new CreditCard("card5", 4444444444444444,
                123, userInfo, 5.8F, 850);
            
            List<PaymentCard> paymentCards = new List<PaymentCard>{card1, card2, card3, card4, card5};
            Wallet wallet = new Wallet(paymentCards);
            
            wallet.Pay(boots.Price);
        }
    }
}