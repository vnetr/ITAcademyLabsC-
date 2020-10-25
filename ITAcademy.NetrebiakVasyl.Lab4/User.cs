using System;
using System.Collections.Generic;
using System.Text;
using TechShop;


namespace TechShop
{
    /// <summary>
    /// Class of User
    /// </summary>
    class User
    {
        public string name { get; private set; }
        public string adress { get; private set; }
        public double balance { get; private set; }
        public double spent { get; private set; }


        public List<Product> listOfPurchase = new List<Product>();

        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="name"></param>
        /// <param name="adress"></param>
        /// <param name="balance"></param>
        /// <param name="spent"></param>
        public User(string name, string adress, double balance, double spent)
        {
            this.name = name;
            this.adress = adress;
            this.balance = balance;
            this.spent = spent;
        }
        /// <summary>
        /// Gets user data
        /// </summary>
        /// <returns>All data in str</returns>
        public StringBuilder GetUserData()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Name: " + this.name + "\n");
            str.Append("Adress: " + this.adress + "\n");
            str.Append("Balance: " + this.balance + "\n");
            str.Append("Spent: " + this.spent + "\n");
            return str;
        }

        /// <summary>
        ///Reduces balance of user after purchase
        /// </summary>
        /// <param name="price"></param>
        public void ReduceBalance(double price)
        {
            balance -= price;
            spent += price;
        }
    }
}
