using System;
using System.IO;


namespace TechShop
{
    /// <summary>
    /// Class for User and Product interaction
    /// </summary>
    class Informer
    {
        private const string path = @"D:\PATH\info.txt";

        /// <summary>
        /// Makes transaction and writes check in file
        /// </summary>
        /// <param name="user"></param>
        public void Buy(User user)
        {
            for (int i = 0; i < user.listOfPurchase.Count; ++i)
            {
                double price = user.listOfPurchase[i].GetDiscountPrice(user);
                user.ReduceBalance(price);
                try
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write("[Customer] ");
                            sw.WriteLine(user.GetUserData());
                            sw.WriteLine();
                        }
                    }

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("[PRODUCT]");
                        sw.WriteLine(user.listOfPurchase[i].GetInfo());
                        sw.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        /// <summary>
        ///Displays check from file 
        /// </summary>
        public void GiveCheck()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Shows list of products of User
        /// </summary>
        /// <param name="user"></param>
        public void ShowPurchaseList(User user)
        {
            for (int i = 0; i < user.listOfPurchase.Count; i++)
            {
                Console.WriteLine($"{i + 1}." + user.listOfPurchase[i].GetInfo());
            }
        }

        /// <summary>
        /// Counts sum of list of products of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public double CountSumOfPurchase(User user)
        {
            double sum = user.listOfPurchase[0].price;
            for(int i = 0; i < user.listOfPurchase.Count; ++i)
            {
                sum += user.listOfPurchase[i].price;
            }
            return sum;
        }


    }

}





