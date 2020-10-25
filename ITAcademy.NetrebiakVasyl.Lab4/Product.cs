using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop
{
    /// <summary>
    /// Abstract class for different Products
    /// </summary>
    abstract class Product
    {
        private const int MIN_DISCOUNT = 300;
        private const int MAX_DISCOUNT = 1000;
        private const double firstDiscount = 0.8;
        private const double secondDiscount = 0.5;
        public double price { get; set; }
        public string name { get; set; }
        public string manufacturer { get; set; }

        /// <summary>
        /// Abstract method
        /// </summary>
        /// <returns></returns>
        public abstract StringBuilder GetInfo();

        /// <summary>
        /// Overloads operator +
        /// </summary>
        /// <param name="product1"></param>
        /// <param name="product2"></param>
        /// <returns>Sum of price</returns>
        public static double operator + (Product product1, Product product2)
        {
            return product1.price + product2.price;
        }

        /// <summary>
        /// Gets discount price
        /// </summary>
        /// <param name="user"></param>
        /// <returns>New price</returns>
        public virtual double GetDiscountPrice(User user)
        {
            if (user.spent < MIN_DISCOUNT)
            {
                return price;
            }

            if ((MIN_DISCOUNT <= user.spent)&&(user.spent <= MAX_DISCOUNT))
            {
                return price * firstDiscount;
            }

            return price * secondDiscount;
        }
    }
}
