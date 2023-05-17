using QA_Auto_BankApp.Comparers;
using QA_Auto_BankApp.Enums;
using QA_Auto_BankApp.Models;
using QA_Auto_BankApp.Models.BankClientInfo;
using QA_Auto_BankApp.Models.PaymentMethods;

namespace QA_Auto_BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userInfo1 = new UserInfo("Jan", "Kowalski", new Address("Lesnaya",
                11101, "Warsaw", "Poland", 49, 209), "+48555555555");

            var userInfo2 = new UserInfo("Marusia", "Lutshaya", new Address("Solnyechnaya",
                11102, "Minsk", "Belarus", 9, 19), "+48555555551");

            var userInfo3 = new UserInfo("Jon", "Kristos", new Address("Kalashki",
                11103, "Vilnus", "Latvia", 45, 59), "+48555555552");

            var paymentMethod1 = new DebitCard("DebitCard1", "0000000000000000",
                111, userInfo1, 1.1F, 200);
            var paymentMethod2 = new CreditCard("CreditCard1", "1111111111111111",
                112, userInfo1, 1.2F, 570);
            var paymentMethod3 = new CashbackCard("CashbackCard1", "2222222222222221",
                113, userInfo1, 1.3F, 900);
            var paymentMethod4 = new Cash("Cash", 100);
            var paymentMethod5 = new BitCoin("BTC", 20000, 0.1f);

            var paymentMethod6 = new DebitCard("DebitCard2", "1111111111111112",
                221, userInfo2, 2.1F, 190);
            var paymentMethod7 = new CreditCard("CreditCard2", "3333333333333332",
                222, userInfo2, 2.2F, 78000);
            var paymentMethod8 = new CashbackCard("CashbackCard3", "2222222222222222",
                223, userInfo2, 2.3F, 909);
            var paymentMethod9 = new Cash("Cash", 100);
            var paymentMethod10 = new BitCoin("BTC", 20000, 0.2f);

            var paymentMethod11 = new DebitCard("DebitCard3", "1111111111111113",
                331, userInfo2, 3.1F, 290);
            var paymentMethod12 = new CreditCard("CreditCard3", "4444444444444443",
                332, userInfo3, 3.2F, 8850);
            var paymentMethod13 = new CashbackCard("CashbackCard3", "2222222222222223",
                333, userInfo3, 3.3F, 700);
            var paymentMethod14 = new Cash("Cash", 100);
            var paymentMethod15 = new BitCoin("BTC", 20000, 0.3f);

            var bankClient1 = new BankClient(userInfo1);
            var bankClient2 = new BankClient(userInfo2);
            var bankClient3 = new BankClient(userInfo3);

            bankClient1.AddPaymentMethod(paymentMethod1);
            bankClient1.AddPaymentMethod(paymentMethod2);
            bankClient1.AddPaymentMethod(paymentMethod3);
            bankClient1.AddPaymentMethod(paymentMethod4);
            bankClient1.AddPaymentMethod(paymentMethod5);

            bankClient2.AddPaymentMethod(paymentMethod6);
            bankClient2.AddPaymentMethod(paymentMethod7);
            bankClient2.AddPaymentMethod(paymentMethod8);
            bankClient2.AddPaymentMethod(paymentMethod9);
            bankClient2.AddPaymentMethod(paymentMethod10);

            bankClient3.AddPaymentMethod(paymentMethod11);
            bankClient3.AddPaymentMethod(paymentMethod12);
            bankClient3.AddPaymentMethod(paymentMethod13);
            bankClient3.AddPaymentMethod(paymentMethod14);
            bankClient3.AddPaymentMethod(paymentMethod15);

            var bankClients = new List<BankClient>
            {
                bankClient1,
                bankClient2,
                bankClient3
            };

            var sortedBankClientsByName = bankClients.OrderBy(x => x.UserInfo.Name).ToList();
            var sortedBankClientsByAddress = bankClients.OrderBy(x => x.UserInfo.Address.Country)
                .ThenBy(x => x.UserInfo.Address.City).ThenBy(x => x.UserInfo.Address.Postcode)
                .ThenBy(x => x.UserInfo.Address.Street).ThenBy(x => x.UserInfo.Address.BuildingNumber)
                .ThenBy(x => x.UserInfo.Address.Apartment).ToList();

            var sortedBankClientsByTotalAmount = bankClients.OrderBy(x =>
                x.PaymentMethodsByName.Keys.Sum(key => x.PaymentMethodsByName[key]
                    .Sum(paymentMethod => paymentMethod.GetBalance()))).ToList();

            var sortedBankClientsNumberOfCards = bankClients.OrderBy(x =>
                x.PaymentMethodsByName.Keys.Where(key =>
                        key is PaymentType.DebitCard or PaymentType.CreditCard or PaymentType.CashbackCard)
                    .Sum(key => x.PaymentMethodsByName[key].Count)).ToList();

            var sortedBankClientMaxAmountOnOnePayMethod = bankClients.OrderBy(x =>
                x.PaymentMethodsByName.Values.SelectMany(y => y).Select(y => y.GetBalance()).Max()).ToList();

            foreach (var client in bankClients)
            {
                Console.WriteLine(client);
            }

            var userInfo4 = new UserInfo("Peter", "Pan", new Address("Forest",
                11102, "Dortmund", "Germany", 33, 219), "+48444444444");
            var userInfo5 = new UserInfo("Peter", "Pan", new Address("Forest",
                11102, "Dortmund", "Germany", 33, 219), "+48444444444");
            var bankClient4 = new BankClient(userInfo4);
            var bankClient5 = new BankClient(userInfo5);

            bankClient4.AddPaymentMethod(new BitCoin("My BTC", 30000, 0.5f));
            bankClient5.AddPaymentMethod(new DebitCard("My Card", "4444444444444444", 333, userInfo5, 0, 10000f));
            bankClient5.AddPaymentMethod(new Cash("Cash", 5000f));

            Console.WriteLine(bankClient4.Equals(bankClient5));
        }
    }
}