namespace QA_Auto_BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var card1 = new DebitCard("card1", 0000000000000000,
                123, new UserInfo("Jan" ,"Kowalski", new Address("Lesnaya", 11100, "Warsaw", "Poland" , 49, 209), "+48555555555"), 2.4, 20000);
            var card2 = new DebitCard("card2", 1111111111111111,
                123, new UserInfo("Tomek" ,"Dupczynski", new Address("Solnechnaya", 11101, "Baranovichi", "Belarus", 8, 46 ), "+48555555556"), 5.7, 29000);
            var card3 = new DebitCard("card3", 2222222222222222,
                123, new UserInfo("Zbigniew" ,"Romualdowicz", new Address("Pieski", 11111, "Kiev", "Ukraine" , 89, 107), "+48555555558"), 3.5, 90000);
            var card4 = new CreditCard("card4", 3333333333333333,
                123, new UserInfo("Aleksander" ,"Zabowski", new Address("Horoshaya", 11102, "Dortmund", "Deutschland", 8, 20 ), "+48555555553" ),7.0,  5000);
            var card5 = new CreditCard("card5", 4444444444444444,
                123, new UserInfo("Sabina" ,"Jaicuk", new Address("Grustnaya", 11103, "Paris", "France",  7, 19), "+48555555585"), 5.8, 85000);


            var array = new PaymentCard[] {card1, card2, card3, card4, card5};

            foreach (var el in array)
            {
                if (el is DebitCard debitCard)
                {
                    debitCard.GetCardInfo(debitCard.ToString());
                }
                else if (el is CreditCard creditCard)
                {
                    creditCard.GetCardInfo(creditCard.ToString());
                }

            }
        }
    }
}