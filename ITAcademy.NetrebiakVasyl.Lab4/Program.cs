using System;
using TechShop.Products;


namespace TechShop
{
    class Program
    {
        static void Main(string[] args)
        {

            char choice;
            User user1 = new User("Vasyl Netrebiak", "Lesya Ukrainka st.", 3250, 100);
            FlashDrive flash1 = new FlashDrive("Flash-Royal", 200, "Kingston", 16, "Grey", "Type-C");
            Game game1 = new Game("GTA", "Action", 800, "RockStar", "PS4");
            Headphones headphones1 = new Headphones("Beats", 600, "Apple", "In-Ear", "White", "Wireless");
            Phone phone1 = new Phone("IPhone", 30000, "Apple", 8, 260, "Black", true);


            Product[] products = new Product[] { flash1, game1, headphones1, phone1 };
            Informer informer = new Informer();


            Console.WriteLine($"Hello {user1.name}, your balance {user1.balance}");
            Console.WriteLine();
            Console.WriteLine("There are our products");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i+1}." + products[i].GetInfo());
            }

            while (true)
            {
                Console.WriteLine("Choose number of product to add to your purchase list and press Enter:");

                string str = Console.ReadLine();
                int productNumber = Convert.ToInt32(str);
                productNumber--;

                if (productNumber >= 0 && productNumber < products.Length)
                {

                    if (products[productNumber].price < user1.balance)
                    {
                        user1.listOfPurchase.Add(products[productNumber]);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect value");
                }
                Console.WriteLine("Do you want add something else?(y/n)");

                choice = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (choice == 'y')
                {
                    continue;
                }
                if (choice == 'n') 
                {
                    break;
                }

            }
            Console.WriteLine($"Your balance: {user1.balance}");
            Console.WriteLine("Your purchase list:");
            informer.ShowPurchaseList(user1);
            double totalPrice = informer.CountSumOfPurchase(user1);
            Console.WriteLine("Total cost: " + totalPrice);
            while (true)
            {
                Console.WriteLine("Want to confirm your purchase?(y/n)");
                choice = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (choice == 'y')
                {
                    if (totalPrice <= user1.balance)
                    {
                        informer.Buy(user1);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("insufficient funds");
                        continue;
                    }
                }
                else if (choice == 'n')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Icorrect input");
                }
            }

            Console.WriteLine("Your check");
            informer.GiveCheck();

            Console.WriteLine("GoodBye");
            Console.ReadKey();
            GC.Collect();
        }
    }
}
