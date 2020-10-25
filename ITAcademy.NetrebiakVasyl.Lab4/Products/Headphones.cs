using System;
using System.Collections.Generic;
using System.Text;

namespace TechShop.Products
{   
    /// <summary>
     /// Class Game Derived Class of Product
     /// </summary>
    class Headphones : Product
    {
        public string color { get; private set; }
        public string type { get; private set; }
        public string connection { get; private set; }
        /// <summary>
        /// Constructor of Headphones
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="manufacturer"></param>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="connection"></param>
        public Headphones(string name, int price, string manufacturer, string type, string color, string connection)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;
            this.type = type;
            this.color = color;
            this.connection = connection;
        }
        /// <summary>
        /// Info about all proparties of HeadPhones
        /// </summary>
        /// <returns>All info in str</returns>
        public override StringBuilder GetInfo()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Name: " + this.name + "\n");
            str.Append("Color: " + this.color + "\n");
            str.Append("Type: " + this.type + "\n");
            str.Append("Connector: " + this.connection + "\n");
            str.Append("Manufacturer: " + this.manufacturer + "\n");
            str.Append("Price:" + this.price + "\n");
            return str;
        }
    }
}
