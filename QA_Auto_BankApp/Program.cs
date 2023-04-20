using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.BankClientInfo;
using QA_Auto_BankApp.Models.PaymentMethods;

namespace QA_Auto_BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserInfo userInfo1 = new UserInfo("Jan", "Kowalski", new Address("Lesnaya",
                11101, "Warsaw", "Poland", 49, 209), "+48555555555");
            
            UserInfo userInfo2 = new UserInfo("Marusia", "Lutshaya", new Address("Solnyechnaya",
                11102, "Minsk", "Belarus", 9, 19), "+48555555551");

            UserInfo userInfo3 = new UserInfo("Jon", "Kristos", new Address("Kalashki",
                11103, "Vilnus", "Latvia", 45, 59), "+48555555552");

            var paymentMethod1 = new DebitCard("DebitCard1", 0000000000000000,
                111, userInfo1, 1.1F, 200);
            var paymentMethod2 = new CreditCard("CreditCard1", 1111111111111111,
                112, userInfo1, 1.2F, 570);
            var paymentMethod3 = new CashbackCard("CashbackCard1", 2222222222222221,
                113, userInfo1, 1.3F, 900);
            var paymentMethod4 = new Cash("Cash", 100);
            var paymentMethod5 = new BitCoin("BTC", 20000, 0.1f);
            
            var paymentMethod6 = new DebitCard("DebitCard2", 1111111111111112,
                221, userInfo2, 2.1F, 190);
            var paymentMethod7 = new CreditCard("CreditCard2", 3333333333333332,
                222, userInfo2, 2.2F, 78000);
            var paymentMethod8 = new CashbackCard("CashbackCard3", 2222222222222222,
                223, userInfo2, 2.3F, 909);
            var paymentMethod9 = new Cash("Cash", 100);
            var paymentMethod10 = new BitCoin("BTC", 20000, 0.2f);

            var paymentMethod11 = new DebitCard("DebitCard3", 1111111111111113,
                331, userInfo2, 3.1F, 290);
            var paymentMethod12 = new CreditCard("CreditCard3", 4444444444444443,
                332, userInfo3, 3.2F, 8850);
            var paymentMethod13 = new CashbackCard("CashbackCard3", 2222222222222223,
                333, userInfo3, 3.3F, 700);
            var paymentMethod14 = new Cash("Cash", 100);
            var paymentMethod15 = new BitCoin("BTC", 20000, 0.3f);
            
            BankClient bankClient1 = new BankClient(userInfo1);
            BankClient bankClient2 = new BankClient(userInfo2);
            BankClient bankClient3 = new BankClient(userInfo3);

            bankClient1.AddPaymentMethod("DebitCard", paymentMethod1);
            bankClient1.AddPaymentMethod("CreditCard", paymentMethod2);
            bankClient1.AddPaymentMethod("CashbackCard", paymentMethod3);
            bankClient1.AddPaymentMethod("Cash", paymentMethod4);
            bankClient1.AddPaymentMethod("BitCoin", paymentMethod5);
            
            bankClient2.AddPaymentMethod("DebitCard", paymentMethod6);
            bankClient2.AddPaymentMethod("CreditCard", paymentMethod7);
            bankClient2.AddPaymentMethod("CashbackCard", paymentMethod8);
            bankClient2.AddPaymentMethod("Cash", paymentMethod9);
            bankClient2.AddPaymentMethod("BitCoin", paymentMethod10);

            bankClient3.AddPaymentMethod("DebitCard", paymentMethod11);
            bankClient3.AddPaymentMethod("CreditCard", paymentMethod12);
            bankClient3.AddPaymentMethod("CashbackCard", paymentMethod13);
            bankClient3.AddPaymentMethod("Cash", paymentMethod14);
            bankClient3.AddPaymentMethod("BitCoin", paymentMethod15);
            
            var bankClients = new List<BankClient>
            {
                bankClient1,
                bankClient2,
                bankClient3
            };

            var comparerList = new List<IComparer<BankClient>>
            {
                new BankClientByNameComparer(),
                new BankClientAddressComparer(),
                new BankClientTotalAmountComparer(),
                new BankClientNumberOfCardsComparer(),
                new BankClientMaxAmountOnOnePayMethodComparer()
            };

            foreach (var comparer in comparerList)
            {
                bankClients.Sort(comparer);

                foreach (var client in bankClients)
                {
                    Console.WriteLine(client);
                }

                Console.WriteLine();
            }
        }
    }
}